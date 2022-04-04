using MajorKeyTruckingMVCProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MajorKeyTrucking.Data
{
    public abstract class GenericRepository<T> :
        IRepository<T> where T : class
    {
        private ApplicationDbContext db;

        public GenericRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public virtual void Add(T entity)
        {
            db.Add(entity);
            db.SaveChanges();
            //throw new NotImplementedException();
        }

        public virtual void Delete(Guid id)
        {
            var entity = db.Find<T>(id);
            db.Remove<T>(entity);
            db.SaveChanges();

            //throw new NotImplementedException();
        }

        public virtual T Get(Guid id)
        {
            return db.Find<T>(id);
           
        }

        public virtual IEnumerable<T> GetAll()
        {
            return db.Set<T>()
                .ToList();
        }

        public virtual void Update(T entity)
        {
            db.Update(entity);
            db.SaveChanges();
        }
    }
}
