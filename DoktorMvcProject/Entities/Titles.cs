using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoktorMvcProject.Entities
{
    public class Titles
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100,MinimumLength =5)]
        public string Title { get; set; }

        public virtual List<Doctor> Doctors { get; set; }

    }
}