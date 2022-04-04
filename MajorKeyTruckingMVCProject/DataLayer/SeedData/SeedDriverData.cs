using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MajorKeyTrucking.Data;
using MajorKeyTrucking.Data.Models;

namespace MajorKeyTruckingMVCProject.Data.SeedData
{
    internal class SeedDriverData: IEntityTypeConfiguration<Driver>
    {

        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.HasData(
                new Driver { DriverId = 1, FirstName = "Andre", LastName = "Thompson", EmailAddress = "Thompson@gmail.com", StreetAddress = "1234 Patterson Rd", City = "Franklinton", State = "Lousiana", ZipCode = "70438", PhoneNumber = "9855154269", PayModel = "Percentage", DriverPay = 0.25M },
                new Driver { DriverId = 2, FirstName = "Tyrone", LastName = "Magee", EmailAddress = "TyroneMagee@gmail.com", StreetAddress = "1234 Whip St", City = "Hammond", State = "Lousiana", ZipCode = "70401", PhoneNumber = "9855157101", PayModel = "Percentage", DriverPay = 0.27M },
                new Driver { DriverId = 3, FirstName = "Deshara", LastName = "Robertson", EmailAddress = "deshara.hall@gmail.com", StreetAddress = "41403 stonebrook ave", City = "Prairieville", State = "Lousiana", ZipCode = "70769", PhoneNumber = "4692330452", PayModel = "Percentage", DriverPay = 0.28M },
                new Driver { DriverId = 4, FirstName = "Larr", LastName = "Clark", EmailAddress = "larry.clark@gmail.com", StreetAddress = "456 Blossum Lan", City = "Tickfaw", State = "Lousiana", ZipCode = "70745", PhoneNumber = "2252506906", PayModel = "Percentage", DriverPay = 0.28M }
                );
        }

        

        
    }
}
