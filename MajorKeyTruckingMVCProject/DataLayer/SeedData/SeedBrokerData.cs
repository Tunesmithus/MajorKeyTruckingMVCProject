using MajorKeyTrucking.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MajorKeyTruckingMVCProject.Data.SeedData
{
    public class SeedBrokerData : IEntityTypeConfiguration<Broker>
    {
        public void Configure(EntityTypeBuilder<Broker> builder)
        {
            builder.HasData(

                new Broker() { BrokerId = 1, BrokerCompanyName = "Landstar", BrokerPhoneNumber = "5042330456", BrokerEmail = "info@landstar.com" },
                new Broker() { BrokerId = 2, BrokerCompanyName = "JB Hung", BrokerPhoneNumber = "5042330456", BrokerEmail = "info@JBHunt.com" },
                new Broker() { BrokerId = 3, BrokerCompanyName = "R2 Logistics", BrokerPhoneNumber = "5042330456", BrokerEmail = "info@R2Logistics.com" }

                );

            
        }
    }
}
