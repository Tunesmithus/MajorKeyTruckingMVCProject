using MajorKeyTrucking.Data.MockUpData;
using MajorKeyTrucking.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MajorKeyTruckingMVCProject.Data
{
    public class SqlLoadData:ILoadRepository
    {
        private ApplicationDbContext db;

        public SqlLoadData(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(Load load)
        {
            db.Add(load);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var load = db.Loads.Find(id);
            db.Loads.Remove(load);
            db.SaveChanges();
        }

        public Load Get(int id)
        {
            var load = db.Loads.FirstOrDefault(l => l.LoadId == id);
            return load;
            
        }

        public IEnumerable<Load> GetAll()
        {
            return from l in db.Loads
                   orderby l.LoadId
                   select l;

        }

        public void Update(Load load)
        {
            var entry = db.Entry(load);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
