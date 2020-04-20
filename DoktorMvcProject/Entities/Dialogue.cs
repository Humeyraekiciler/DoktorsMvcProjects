using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoktorMvcProject.Entities
{
    public class Dialogue
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }

        public int IllPersonId { get; set; }

        public virtual IllPerson IllPerson { get; set; }
      
        public string DP_Dialogue { get; set; }

        public bool Writer { get; set; }

        public DateTime DP_Date { get; set; }
    }
}