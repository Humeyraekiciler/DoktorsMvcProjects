using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoktorMvcProject.Entities
{
    public class Doctor_IllPerson
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }

        public int IllPersonId { get; set; }

        public virtual IllPerson IllPerson { get; set; }


    }
}