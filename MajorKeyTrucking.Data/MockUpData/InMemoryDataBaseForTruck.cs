using MajorKeyTrucking.Data.Models;
using MajorKeyTrucking.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorKeyTrucking.Data.MockUpData
{
    public class InMemoryDataBaseForTruck: ITruckRepository
    {
        List<Truck> trucks;
        public InMemoryDataBaseForTruck()
        {
            trucks = new List<Truck>()
            {
                new Truck{TruckId = 1, VinNumber = "1234567890123456", Year = 2016, Make = "Freightliner", Model = "Cascadia", EquipmentNumber = "100" },
                new Truck{TruckId = 2, VinNumber = "1234567890123454", Year = 2016, Make = "Freightliner", Model = "Cascadia", EquipmentNumber = "101" }
            };

        }

        public void Add(Truck truck)
        {
            trucks.Add(truck);
            truck.TruckId = trucks.Max(t => t.TruckId) + 1;
        }

       

        public void Delete(int id)
        {
            var truck = Get(id);
            if (truck != null)
            {
                trucks.Remove(truck);
            }
        }

        public Truck Get(int id)
        {
            var truck = trucks.FirstOrDefault(t => t.TruckId == id);
            return truck;
        }

        public IEnumerable<Truck> GetAll()
        {
            var truck = trucks.OrderBy(t=>t.TruckId);
            return truck;
        }

        public void Update(Truck truck)
        {
            var existing = Get(truck.TruckId);
            if (existing != null)
            {
                existing.VinNumber = truck.VinNumber;
                existing.Year = truck.Year;
                existing.Make = truck.Make;
                existing.Model = truck.Model;
                existing.EquipmentNumber = truck.EquipmentNumber;

            }


        }
    }
}
