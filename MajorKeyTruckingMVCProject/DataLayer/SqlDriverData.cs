using MajorKeyTrucking.Data;
using MajorKeyTruckingMVCProject.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MajorKeyTruckingMVCProject
{
    public class SqlDriverData : IDriverRepository
    {
        private ApplicationDbContext db;

        public SqlDriverData(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Add(Driver driver)
        {
            db.Drivers.Add(driver);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var driver = db.Drivers.Find(id);
            db.Drivers.Remove(driver);
            db.SaveChanges();
        }

        public Driver Get(int id)
        {
            return db.Drivers.FirstOrDefault(d => d.DriverId == id);
        }

        public IEnumerable<Driver> GetAll()
        {
            return from d in db.Drivers
                   orderby d.DriverId
                   select d;
        }

        public void Update(Driver driver)
        {
            /* Update syntax without optomistic concurrency
            var d = Get(driver.DriverId);
            d.FirstName = "";
            d.LastName = ""; */

            //Update syntax with optomistic concurrency
            var entry = db.Entry(driver);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
