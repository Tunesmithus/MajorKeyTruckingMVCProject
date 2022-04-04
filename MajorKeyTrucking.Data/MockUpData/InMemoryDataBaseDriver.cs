using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorKeyTrucking.Data
{
    public class InMemoryDataBaseDriver:IDriverRepository
    {
        List<Driver> drivers;
        public InMemoryDataBaseDriver()
        {
            
            drivers = new List<Driver>()
            {
                new Driver{DriverId = 1, FirstName = "Channing", LastName = "Robertson", EmailAddress = "Channing.robertson@gmail.com", StreetAddress = "41403 Stonebrook ave", City ="Prairieville", State = "Louisiana", ZipCode= "70769", PhoneNumber= "6013108018", PayModel = "Percentage", DriverPay = 0.25M},
                new Driver{DriverId = 2, FirstName = "Kingston", LastName = "Robertson", EmailAddress = "kingtson.robertson@gmail.com", StreetAddress = "41403 Stonebrook ave", City ="Prairieville", State = "Louisiana", ZipCode= "70769", PhoneNumber= "6013108018", PayModel = "Percentage", DriverPay = 0.27M},

            };

        }

        public void Add(Driver driver)
        {
            drivers.Add(driver);
            driver.DriverId = drivers.Max(d => d.DriverId) + 1;
        }

        public void Update(Driver driver)
        {
            var existing = Get(driver.DriverId);
            if (existing != null)
            {
                existing.FirstName = driver.FirstName;
                existing.LastName = driver.LastName;
                existing.EmailAddress = driver.EmailAddress;
            }
        }

        public Driver Get(int id)
        {
            return drivers.FirstOrDefault(d => d.DriverId == id);
        }

        public IEnumerable<Driver> GetAll()
        {
            return drivers.OrderBy(d => d.DriverId);
        }

        public void Delete(int id)
        {
            var driver = Get(id);
            if (driver != null)
            {
                drivers.Remove(driver);
            }
        }
    }
}
