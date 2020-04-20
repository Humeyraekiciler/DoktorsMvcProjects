using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoktorMvcProject.Entities
{
    public class Users
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string IdendityNo { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}