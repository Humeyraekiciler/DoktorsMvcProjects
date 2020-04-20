using DoktorMvcProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoktorMvcProject.Models.DoctorsModel
{
    public class DoctorCreateViewModel
    {
        //public int Id { get; set; }

        public List<Doctor> Doctors { get; set; }

        public SelectList Titles { get; set; }

    }
}