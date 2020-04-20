using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoktorMvcProject.Entities
{
    public class Doctor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Surname{ get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int TitleId { get; set; }

        public virtual Titles Title { get; set; }

        public virtual List<Doctor_IllPerson> Doctor_IllPersons { get; set; }

        public virtual List<Dialogue> DP_Dialouges { get; set; }//bir doktorun birden fazla yazışması olabilir

        public string UserId { get; set; }
    }
}