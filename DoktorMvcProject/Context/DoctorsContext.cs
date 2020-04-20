using DoktorMvcProject.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DoktorMvcProject.Context
{
    public class DoctorsContext:DbContext
    {
        public DoctorsContext():base("defaultConnection")
        {

        }
        public virtual DbSet<Doctor> Doctors { get; set; }//tablo adları

        public virtual DbSet<IllPerson> IllPersons { get; set; }

        public virtual DbSet<Doctor_IllPerson> Doctor_IllPersons { get; set; }

        public virtual DbSet<Users> Users { get; set; }

        public virtual DbSet<Titles> Titles { get; set; }

        public virtual DbSet<Dialogue> Dialogues { get; set; }

        
    }
}