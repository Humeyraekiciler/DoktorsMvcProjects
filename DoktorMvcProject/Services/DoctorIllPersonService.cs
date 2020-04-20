using DoktorMvcProject.Context;
using DoktorMvcProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoktorMvcProject.Services
{
    public class DoctorIllPersonService
    {
        DoctorsContext db = new DoctorsContext();

        public List<Doctor_IllPerson> GetList()
        {
            return db.Doctor_IllPersons.ToList();
        }
    }
}