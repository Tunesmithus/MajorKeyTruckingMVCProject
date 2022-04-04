using MajorKeyTrucking.Data.Models;
using MajorKeyTrucking.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MajorKeyTruckingMVCProject.Data
{
    public class SqlBrokerData: IBrokerRepository
    {
        private ApplicationDbContext db;

        public SqlBrokerData(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(Broker broker)
        {
            db.Brokers.Add(broker);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var broker = db.Brokers.Find(id);
            db.Remove(broker);
            db.SaveChanges();
        }

        public Broker Get(int id)
        {
            var broker = db.Brokers.FirstOrDefault(b => b.BrokerId == id);
            return broker;
            
        }

        public IEnumerable<Broker> GetAll()
        {
            return from b in db.Brokers
                   orderby b.BrokerId
                   select b;
        }

        public void Update(Broker broker)
        {
            /* Update syntax without optomistic concurrency
           var d = Get(broker.BrokerId);
           d.FirstName = "";
           d.LastName = ""; */

            //Update syntax with optomistic concurrency
            var entry = db.Entry(broker);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
