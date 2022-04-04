using MajorKeyTrucking.Data.Models;
using MajorKeyTrucking.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MajorKeyTruckingMVCProject.Data
{
    public class SqlTruckData : ITruckRepository
    {
        private ApplicationDbContext db;

        public SqlTruckData(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Add(Truck truck)
        {
            db.Add(truck);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var truck = db.Trucks.Find(id);
            db.Trucks.Remove(truck);
            db.SaveChanges();
            
        }

        public Truck Get(int id)
        {
            var truck = db.Trucks.FirstOrDefault(t => t.TruckId == id);
            return truck;
           
        }

        public IEnumerable<Truck> GetAll()
        {
            var truck = from t in db.Trucks
                        orderby t.TruckId
                        select t;
                           
            return truck;
        }

        public void Update(Truck truck)
        {
            /* Update syntax without optomistic concurrency
            var d = Get(driver.DriverId);
            d.FirstName = "";
            d.LastName = ""; */

            //Update syntax with optomistic concurrency
            var entry = db.Entry(truck);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
