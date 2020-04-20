using DoktorMvcProject.Context;
using DoktorMvcProject.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DoktorMvcProject.Services
{
    public class IllPersonService
    {
        DoctorsContext db =new DoctorsContext();

        public List<IllPerson> GetList()
        {
            return db.IllPersons.ToList();
        }

        public IQueryable<IllPerson> GetQuery()
        {
            return db.IllPersons.AsQueryable();
        }

        public IllPerson GetById(int? id)
        {
            return db.IllPersons.Find(id);
        }

        public void Add(IllPerson ıllPerson)
        {
            db.IllPersons.Add(ıllPerson);
            db.SaveChanges();
        }
        
        public void Update(IllPerson ıllPerson)
        {
            db.Entry(ıllPerson).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int? id)
        {
            var entity = db.IllPersons.Find(id);
            db.IllPersons.Remove(entity);
            db.SaveChanges();
        }
    }
}