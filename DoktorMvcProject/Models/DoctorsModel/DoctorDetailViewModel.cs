using DoktorMvcProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoktorMvcProject.Models.DoctorsModel
{
    public class DoctorDetailViewModel
    {
        public int Id { get; set; }

        public List<Doctor> Doctors { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }



    }
}