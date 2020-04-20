using DoktorMvcProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoktorMvcProject.Models.DoctorsModel
{
    public class DoctorIndexViewModel
    {
        
        public int Id { get; set; }
       //Bu model indexviewında gösterilecek ve orada birden fazla doktor olabilr dolayısıyla birden fazla ünvan olabilir
        public List<Doctor> Doctors { get; set; }//birden fazla doktoru göstermek için boş bir liste oluşturuyoruz

        public SelectList Titles { get; set; }//boş bir tittle türünde titles listesi oluturuyoruz

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int TitleId { get; set; }
    }
}