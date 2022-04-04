using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorKeyTrucking.Data
{
    public interface IDriverRepository
    {
        IEnumerable<Driver> GetAll();

        Driver Get(int id);

        void Add(Driver driver);

        void Update(Driver driver);

        void Delete(int id);
    }
}
