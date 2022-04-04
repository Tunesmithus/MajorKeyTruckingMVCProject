using MajorKeyTrucking.Data.Models;
using MajorKeyTrucking.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MajorKeyTruckingMVCProject.Data
{
    public class SqlTrailerData : ITrailerRepository
    {
        private ApplicationDbContext db;

        public SqlTrailerData(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Add(Trailer trailer)
        {
            db.Add(trailer);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var trailer = db.Trailers.Find(id);
            db.Trailers.Remove(trailer);
            db.SaveChanges();
        }

        public Trailer Get(int id)
        {
            var trailer = db.Trailers.FirstOrDefault(t => t.TrailerId == id);
            return trailer;
        }

        public IEnumerable<Trailer> GetAll()
        {
            var trailers = from t in db.Trailers
                           orderby t.TrailerId
                           select t;
            return trailers;         
                          
        }

        public void Update(Trailer trailer)
        {
            /* Update syntax without optomistic concurrency
            var d = Get(driver.DriverId);
            d.FirstName = "";
            d.LastName = ""; */

            //Update syntax with optomistic concurrency
            var entry = db.Entry(trailer);
            entry.State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}
