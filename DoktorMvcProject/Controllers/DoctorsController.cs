using DoktorMvcProject.Context;
using DoktorMvcProject.Entities;
using DoktorMvcProject.Models.DoctorsModel;
using DoktorMvcProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DoktorMvcProject.Controllers
{
    public class DoctorsController : Controller
    {
        DoctorsContext db = new DoctorsContext();
        DoctorService doctorService = new DoctorService();
        TitleService titleService = new TitleService();
        DoctorIllPersonService doctorIllPersonService = new DoctorIllPersonService();
        // GET: Doctors
        public ActionResult Index(DoctorIndexViewModel doctorIndexViewModel)
        {//hem doktorlar hem de title'ları listelenecek:

            var query = doctorService.GetQuery();
            var titles = titleService.GetList().Select(e => new SelectListItem()
            {//aşağıda db.Titles yazmak yerine burda servisten çekilp value ve text değeri bulunurak yapıldı.Garanti yol.
                Value = e.Id.ToString(),
                Text = e.Title
            });

            if (doctorIndexViewModel.TitleId!=0)
            {//search için yaptık burayı dolayısıyla GetQuery de search için oluşturuldu.
                query = query.Where(e => e.TitleId == doctorIndexViewModel.TitleId);//title'a uyan doktor getirilir.
            }
            doctorIndexViewModel.Doctors = query.ToList();//koşula uyan doktor doctors listesine atıldı.Listeleme için.
            doctorIndexViewModel.Titles = new SelectList(titles, "Value", "Text", doctorIndexViewModel.TitleId);
            return View(doctorIndexViewModel);
          
        }

        public ActionResult Details(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var doctor = db.Doctors.Find(id);
            var doctor = doctorService.GetById(id);
            if (doctor == null)
            {
              return HttpNotFound();
            }

            return View(doctor);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.TitleId = new SelectList(db.Titles, "Id", "Title");//title id ve name'i ile döndürülür.
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public ActionResult CreateNew([Bind(Include ="Id,Name,Surname,Email,Phone,TitleId")] Doctor doctor)
        {       
            if (ModelState.IsValid)
            {
                doctorService.Add(doctor);
                return RedirectToAction("Index");
            }
            ViewBag.TitleId = new SelectList(db.Titles, "Id", "Title", doctor.TitleId);//title bu bilgilerle eklenir.
            TempData["Info"] = "Record successfully added to database";
            return View(doctor);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = doctorService.GetById(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            ViewBag.TitleId = new SelectList(db.Titles, "Id", "Title", doctor.TitleId);
            return View(doctor);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name,Surname,Email,Phone,TitleId")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                doctorService.Update(doctor);
                return RedirectToAction("Index");
            }
            ViewBag.TitleId = new SelectList(db.Titles, "Id", "Title", doctor.TitleId);
            return View(doctor);
        }

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Id is Request!");
            var model = db.Doctors.FirstOrDefault(e => e.Id == id.Value);
            return View(model);
        }

        [ActionName("Delete")]
        [HttpPost]
        public ActionResult DeleteConfirmed(int? id)
        {
            bool delete = true;
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Id is Request!");

            List<Doctor_IllPerson> doctorIllPerson = doctorIllPersonService.GetList();
            foreach(var doctorıllperson in doctorIllPerson)
            {
                if (doctorıllperson.DoctorId == id)
                {  
                    delete = false;
                    break;
                }
            }
            if (delete)
            {
                doctorService.Delete(id);
                TempData["Info"] = "Record successfully deleted to database";
            }
            else
            {
                TempData["Info"] = "Doctor is not deleted from database";
            }
            return RedirectToAction("Index");


        }
        public ActionResult Welcome()
        {
            var result = "Welcome To My Page";
            return PartialView("_Welcome", result);//result stringini bu partialviewı na gönderir.
        }
       
    }
}