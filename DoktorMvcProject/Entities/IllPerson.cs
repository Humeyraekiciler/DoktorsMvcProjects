using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoktorMvcProject.Entities
{
    public class IllPerson
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Surname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public virtual List<Doctor_IllPerson> Doctor_IllPersons { get; set; }

        public virtual List<Dialogue> DP_Dialouges { get; set; }//bir hastanın birden fazla yazışması olabilir

        public string UserId { get; set; }
    }
}