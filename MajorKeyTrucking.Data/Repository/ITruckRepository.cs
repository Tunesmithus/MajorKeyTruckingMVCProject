using MajorKeyTrucking.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorKeyTrucking.Data.Repository
{
    public interface ITruckRepository
    {
        IEnumerable<Truck> GetAll();

        Truck Get(int id);

        void Add(Truck truck);
        void Update(Truck truck);

        void Delete(int id);
    }
}
