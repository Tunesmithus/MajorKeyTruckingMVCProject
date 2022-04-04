using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorKeyTrucking.Data
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);

        void Delete(Guid id);
        T Get(Guid id);
        IEnumerable<T> GetAll();
    }
}
