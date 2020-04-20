namespace DoktorMvcProject.Migrations
{
    using DoktorMvcProject.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DoktorMvcProject.Context.DoctorsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DoktorMvcProject.Context.DoctorsContext context)
        {
            List<Doctor> DoctorsList = new List<Doctor>()
           {
               new Doctor{ Id=1, Name="Atilla", Surname="AYHAN", Email="atillayhan@gmail.com",
                Phone="03122758494", TitleId=2, Doctor_IllPersons=new List<Doctor_IllPerson>(),DP_Dialouges=new List<Dialogue>()},
           };

            List<IllPerson> IllPersonList = new List<IllPerson>()
            {
                new IllPerson{ Id=1, Name="Sevil", Surname="Ate�", Email="sevilate�@hotmail.com", Phone="05356451232",
                   Doctor_IllPersons=new List<Doctor_IllPerson>(),DP_Dialouges=new List<Dialogue>()},
                new IllPerson{ Id=2, Name="Asu", Surname="Y�lmaz", Email="y�lmazasu@hotmail.com", Phone="05327894589",
                   Doctor_IllPersons=new List<Doctor_IllPerson>(),DP_Dialouges=new List<Dialogue>()},
                new IllPerson{ Id=3, Name="Tar�k", Surname="S�nmez", Email="tar�kSnmz@gmail.com", Phone="05451236312",
                   Doctor_IllPersons=new List<Doctor_IllPerson>(),DP_Dialouges=new List<Dialogue>()},

            };

            List<Doctor_IllPerson> Doctor_IllPersonList = new List<Doctor_IllPerson>
            {
                new Doctor_IllPerson { Id = 1, DoctorId = 1, IllPersonId = 1 },
                new Doctor_IllPerson { Id = 2, DoctorId = 1, IllPersonId = 2 },
                new Doctor_IllPerson { Id = 3, DoctorId = 1, IllPersonId = 3 },

            };
            List<Dialogue> DialogueList = new List<Dialogue>
            {
                new Dialogue{Id=1,DoctorId=1,IllPersonId=2,DP_Dialogue=" �ok halsiz d���yorum. ",Writer=false,DP_Date=DateTime.Now},
                new Dialogue{Id=1,DoctorId=1,IllPersonId=2,DP_Dialogue=" B12'iniz d��m�� olabilir. ",Writer=true,DP_Date=DateTime.Now}
            };
            List<Titles> Titlelist = new List<Titles>
            {
                new Titles{Id=1,Title="Kalp Cerrah�",Doctors=new List<Doctor>()},
                new Titles{Id=2,Title="�� Hastal�klar� Uzman�",Doctors=new List<Doctor>()}
            };


            foreach (Doctor doctor in DoctorsList)
            {
                List<Doctor_IllPerson> doctor_�llPersons = Doctor_IllPersonList.Where(d => d.DoctorId == doctor.Id).ToList();
                List<Dialogue> dp_Dialogue = DialogueList.Where(d => d.DoctorId == doctor.Id).ToList();

                foreach (Doctor_IllPerson doctor_�llPerson in doctor_�llPersons)
                {
                    doctor.Doctor_IllPersons.Add(doctor_�llPerson);
                }
                foreach (Dialogue dialogue in dp_Dialogue)
                {
                    doctor.DP_Dialouges.Add(dialogue);
                }
            }

            foreach (IllPerson �llperson in IllPersonList)
            {
                List<Doctor_IllPerson> doctor_�llPersons = Doctor_IllPersonList.Where(� => �.IllPersonId == �llperson.Id).ToList();
                List<Dialogue> dp_Dialogue = DialogueList.Where(d => d.IllPersonId == �llperson.Id).ToList();
                foreach (Doctor_IllPerson doctor_�llPerson in doctor_�llPersons)
                {
                    �llperson.Doctor_IllPersons.Add(doctor_�llPerson);
                }
                foreach (Dialogue dialogue in dp_Dialogue)
                {
                    �llperson.DP_Dialouges.Add(dialogue);
                }
            }

            foreach (Titles title in Titlelist)
            {
                List<Doctor> doctors = DoctorsList.Where(t => t.TitleId == title.Id).ToList();
                foreach (Doctor doctor in doctors)
                {
                    title.Doctors.Add(doctor);
                }
            }


            //context/update:
            foreach (Titles title in Titlelist)
            {
                context.Titles.AddOrUpdate(d => new { d.Title},
                    new Titles
                    {
                     Id=title.Id,
                     Title=title.Title,
                     Doctors=title.Doctors
                    });
            }
            foreach (IllPerson �llPerson in IllPersonList)
            {
                context.IllPersons.AddOrUpdate(� => new { �.Name, �.Surname },
                    new IllPerson
                    {
                        Name = �llPerson.Name,
                        Surname = �llPerson.Surname,
                        Email = �llPerson.Email,
                        Phone = �llPerson.Phone,
                        Doctor_IllPersons = �llPerson.Doctor_IllPersons,
                        DP_Dialouges = �llPerson.DP_Dialouges,
                        UserId = �llPerson.UserId
                    });
            }
        }
    }
}
