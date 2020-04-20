using DoktorMvcProject.Context;
using DoktorMvcProject.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DoktorMvcProject.Services
{
    public class TitleService
    {
        DoctorsContext db = new DoctorsContext();

        public List<Titles> GetList()
        {
            return db.Titles.ToList();
        }

        public IQueryable<Titles> GetQuery()
        {
            return db.Titles.AsQueryable();
        }

        public Titles GetById(int? id)
        {
            Titles title = db.Titles.Find(id);
            return title;
        }

        public void Add(Titles title)
        {
            db.Titles.Add(title);
            db.SaveChanges();
        }

        public void Update(Titles title)
        {
            db.Entry(title).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int? id)
        {
            var entity = db.Titles.Find(id);
            db.Titles.Remove(entity);
            db.SaveChanges();
        }
    }
}