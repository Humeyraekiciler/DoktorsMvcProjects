using DoktorMvcProject.Context;
using DoktorMvcProject.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DoktorMvcProject.Services
{
    
    public class DoctorService
    {
        DoctorsContext db = new DoctorsContext();
        public List<Doctor> GetList()
        {       
         // return db.Doctors.ToList();
         return db.Doctors.Include("Title").ToList();

        }

        public IQueryable<Doctor> GetQuery()
        {
            return db.Doctors.AsQueryable();
        }

        public Doctor GetById(int? id)
        {
            Doctor doctor =db.Doctors.Find(id);
            return doctor ;
        }

        public void Add(Doctor doctor)
        {
                db.Doctors.Add(doctor);
                db.SaveChanges();

        }

        public void Update(Doctor doctor)
        {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
        }
        public void Delete(int? id)
        {
            var entity = db.Doctors.Find(id);
            db.Doctors.Remove(entity);
            db.SaveChanges();
        }
    }
}