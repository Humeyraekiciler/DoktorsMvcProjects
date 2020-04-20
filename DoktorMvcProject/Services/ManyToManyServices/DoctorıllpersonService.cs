using DoktorMvcProject.Context;
using DoktorMvcProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoktorMvcProject.Services.manytomanyservice
{
    public class DoctorıllpersonService
    {
        DoctorsContext db = new DoctorsContext();
    
        public IQueryable<Doctor_IllPerson> GetQuery()
        {
            return db.Doctor_IllPersons.AsQueryable();
        }

        public void Delete(int? id)
        {
            var doctorIllPersons = db.Doctor_IllPersons.Where(e => e.IllPersonId == id.Value).ToList();
            foreach (var doctorIllPerson in doctorIllPersons)
            {
                db.Doctor_IllPersons.Remove(doctorIllPerson);
                db.SaveChanges();

            }
        }
    }
}