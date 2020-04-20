using DoktorMvcProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoktorMvcProject.Models.IllPersonsModel
{
    public class IllPersonEditViewModel
    {
        public IllPerson IllPerson { get; set; }
        
        public MultiSelectList Doctors { get; set; }

        public List<int> doctorIds { get; set; }
    }
}