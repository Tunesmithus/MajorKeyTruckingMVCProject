using MajorKeyTrucking.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MajorKeyTruckingMVCProject.Data.SeedData
{
    internal class SeedLoadData : IEntityTypeConfiguration<Load>
    {
        public void Configure(EntityTypeBuilder<Load> builder)
        {

            builder.HasData(
                new Load { LoadId = 1,  LoadNumber = "12345", UnloadedMiles = 34, LoadedMiles = 500, PickUpDate = DateTime.Now, DeliveryDate = DateTime.Now, LoadPay = 1700, RatePerMile = 3.18M, DriverId = 1 },
                new Load { LoadId = 2,  LoadNumber = "22345", UnloadedMiles = 0, LoadedMiles = 500, PickUpDate = DateTime.Now, DeliveryDate = DateTime.Now, LoadPay = 1700, RatePerMile = 3.18M, DriverId = 2 },
                new Load { LoadId = 3, LoadNumber = "42345", UnloadedMiles = 0, LoadedMiles = 500, PickUpDate = DateTime.Now, DeliveryDate = DateTime.Now, LoadPay = 1700, RatePerMile = 3.18M, DriverId = 3 }

                );

        }

        
    }
}
