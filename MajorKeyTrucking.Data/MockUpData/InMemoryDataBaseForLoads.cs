using MajorKeyTrucking.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorKeyTrucking.Data.MockUpData
{
    public class InMemoryDataBaseForLoads:ILoadRepository
    {
        
        List<Load> loads;
        public InMemoryDataBaseForLoads()
        {
            loads = new List<Load>()
            {
                new Load{LoadId = 1, LoadNumber= "123456", PickUpDate = DateTime.Parse("1/12/2022"), DeliveryDate = DateTime.Parse("1/13/2022"), UnloadedMiles = 50, LoadedMiles = 400, LoadPay = 1500},
                new Load{LoadId = 2, LoadNumber= "123457", PickUpDate = DateTime.Parse("1/13/2022"), DeliveryDate = DateTime.Parse("1/14/2022"), UnloadedMiles = 50, LoadedMiles = 371, LoadPay = 1400}
            };

        }

        public void Add(Load load)
        {
            loads.Add(load);
            load.LoadId = loads.Max(l => l.LoadId) + 1;
        }

        public void Delete(int id)
        {
            var load = Get(id);
            if (load != null)
            {
                loads.Remove(load);
            }
        }

        public Load Get(int id)
        {
            var load = loads.FirstOrDefault(l => l.LoadId == id);
            return load;
        }

        public IEnumerable<Load> GetAll()
        {
            var load = loads.OrderBy(l => l.LoadId);
            return load;

        }

        public void Update(Load load)
        {
            var existing = Get(load.LoadId);
            if (existing != null)
            {
               
                existing.LoadNumber = load.LoadNumber;
                existing.UnloadedMiles = load.UnloadedMiles;
                existing.LoadedMiles = load.LoadedMiles;
                existing.PickUpDate = load.PickUpDate;
                existing.DeliveryDate = load.DeliveryDate;
                existing.LoadPay = load.LoadPay;

            }
        }
    }
}
