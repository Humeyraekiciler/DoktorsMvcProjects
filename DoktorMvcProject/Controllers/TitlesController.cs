using DoktorMvcProject.Context;
using DoktorMvcProject.Entities;
using DoktorMvcProject.Models.TitlesModel;
using DoktorMvcProject.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DoktorMvcProject.Controllers
{
    public class TitlesController : Controller
    {
        TitleService titleService = new TitleService();
        DoctorService doctorService = new DoctorService();
        DoctorsContext db = new DoctorsContext();
        // GET: Titles
        public ActionResult Index()
        {
            //Titles titles = new Titles();
            var model = titleService.GetList();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.Message = "Please enter title informations";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public ActionResult CreateNew([Bind(Include ="Id,Title")] Titles titles)
        {
            var title = new Titles()
            {
               
                Title = Request.Form["Title"],
             
            };
            if (ModelState.IsValid)
            {
                titleService.Add(title);
                return RedirectToAction("Index");
            }
            TempData["Info"] = "Record successfully added to database";
            return View(title);
        }
        
         public ActionResult GetTitleAjax()
        {
            var _titles = titleService.GetList();
            TitlesAjaxCreateViewModel model = new TitlesAjaxCreateViewModel()
            {
                title_list = _titles,
                titles = new Titles()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddTitleAjax(Titles titles)
        {
            List<Titles> _titles = titleService.GetList();
            titles.Id = _titles.Max(e => e.Id) + 1;
            titleService.Add(titles);
            var _newtitles = titleService.GetList();
            return PartialView("_TitleList", _newtitles);
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Titles title = titleService.GetById(id.Value);
            if (title == null)
            {
                return HttpNotFound();
            }
            return View(title);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="Id,Title")] Titles titles)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    titleService.Update(titles);
                    return RedirectToAction("Index");

                }
                return View(titles);
            }
            catch (Exception exc)
            {

                throw exc;
            }
           
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.Titles.FirstOrDefault(e => e.Id == id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Id is Request!");
            }
            titleService.Delete(id.Value);
            return RedirectToAction("Index");
        }
        public ActionResult Welcome()
        {
            var result = "Welcome To My Page";
            return PartialView("_Welcome", result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
