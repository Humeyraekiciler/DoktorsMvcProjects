using DoktorMvcProject.Context;
using DoktorMvcProject.Entities;
using DoktorMvcProject.Models.IllPersonsModel;
using DoktorMvcProject.Services;
using DoktorMvcProject.Services.manytomanyservice;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DoktorMvcProject.Controllers
{
    public class IllPersonsController : Controller
    {
        DoctorsContext db = new DoctorsContext();
        IllPersonService ıllPersonService = new IllPersonService();

        DoctorıllpersonService doctorıllpersonService = new DoctorıllpersonService();
        // GET: Persons
        public ActionResult Index(int? page)
        {
            var model = ıllPersonService.GetList().ToPagedList(page?? 1,2);         
            return View(model);
        }

        public ActionResult Details(int? id)//buna bir de doktorları göstermeyi ekle
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ıllPerson = ıllPersonService.GetById(id);
            if (ıllPerson == null)
            {
                return HttpNotFound();
            }
            return View(ıllPerson);
        }

        public ActionResult Create()
        {
            ViewBag.Message = "Please enter ıllperson informations";
            var doctors = db.Doctors.ToList().Select(e => new SelectListItem()//eklemek için doktorları getiriyoruz
            {
                Value=e.Id.ToString(),
                Text=e.Name+ " " + e.Surname
            });
            ViewData["doctors"] = new MultiSelectList(doctors, "Value", "Text");//birden çok seçilebilirlik.
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreateNew([Bind(Include = "Id,Name,Surname,Email,Phone,")] List<int> Doctors)
        {
            var person = new IllPerson()
            {
                Name = Request.Form["Name"],
                Surname = Request.Form["Surname"],
                Email = Request.Form["Email"],
                Phone = Request.Form["Phone"]             
            };
          
            if (ModelState.IsValid)
            {
                person.Doctor_IllPersons = Doctors.Select(e => new Doctor_IllPerson()
                {
                    IllPersonId = person.Id,
                    DoctorId =e //Doctor içindeki seçilen doktor ıdleri
                }).ToList();
                ıllPersonService.Add(person);
                return RedirectToAction("Index");
            }
            TempData["Info"] = "Record successfully added to database";
            return View(person);       
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var doctors = db.Doctors.Select(e => new SelectListItem()//selectlist ile doctorları çektik ve listeledik.
            {
                Value = e.Id.ToString(),
                Text=e.Name + e.Surname
            }).ToList();
            IllPerson ıllPerson = ıllPersonService.GetById(id.Value);
            List<int> _doctorIds = ıllPerson.Doctor_IllPersons.Select(e => e.DoctorId).ToList();//birden fazla doctoru seçebilmek için multiselectlist yapısı oluşturuldu.
            IllPersonEditViewModel ıllPersonEditViewModel = new IllPersonEditViewModel();
            ıllPersonEditViewModel.IllPerson = ıllPerson;
            ıllPersonEditViewModel.doctorIds = _doctorIds;
            ıllPersonEditViewModel.Doctors = new MultiSelectList(doctors, "Value", "Text", ıllPersonEditViewModel.doctorIds);
            return View("EditNew", ıllPersonEditViewModel);

        }

        [HttpPost]
        public ActionResult Edit(IllPersonEditViewModel ıllPersonEditViewModel)
        {
            if (ModelState.IsValid)
            {
                var ıllPerson = ıllPersonService.GetById(ıllPersonEditViewModel.IllPerson.Id);//id ye karşılık person
                ıllPerson.Name = ıllPersonEditViewModel.IllPerson.Name;
                ıllPerson.Surname = ıllPersonEditViewModel.IllPerson.Surname;
                ıllPerson.Phone = ıllPersonEditViewModel.IllPerson.Phone;
                ıllPerson.Email = ıllPersonEditViewModel.IllPerson.Email;
           
                var doctorIllPersons = db.Doctor_IllPersons.Where(e => e.IllPersonId == ıllPerson.Id).ToList();
                foreach (var doctorIllPerson in doctorIllPersons)
                {
                    db.Doctor_IllPersons.Remove(doctorIllPerson);
                    db.SaveChanges();

                }
                ıllPerson.Doctor_IllPersons = ıllPersonEditViewModel.doctorIds.Select(e => new Doctor_IllPerson()
                {
                    DoctorId = e,
                    IllPersonId = ıllPerson.Id
                }).ToList();
                ıllPersonService.Update(ıllPerson);
                return RedirectToAction("Index");
            }
            return View(ıllPersonEditViewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Id is Request!");
            }
            var model = db.IllPersons.FirstOrDefault(e => e.Id == id.Value);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
           // bool delete = false;
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Id is Request!");
            }
            doctorıllpersonService.Delete(id);
            ıllPersonService.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Welcome()
        {
            var result = "Welcome To My Page";
            return PartialView("_Welcome", result);//result stringini bu partialviewı na gönderir.
        }
    }
}
