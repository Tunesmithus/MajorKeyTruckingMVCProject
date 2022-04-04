using MajorKeyTrucking.Data;
using MajorKeyTrucking.Data.Models;
using MajorKeyTruckingMVCProject.Data.SeedData;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace MajorKeyTruckingMVCProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Load> Loads { get; set; }

        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<Truck> Trucks { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<Broker> Brokers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // BookAuthor: set primary key 
            builder.Entity<Driver>().HasKey(ba => new { ba.DriverId });
            builder.Entity<Load>().HasKey(l => new { l.LoadId });

            // BookAuthor: set foreign keys 
            //builder.Entity<Load>().HasOne(ba => ba.Driver)
            //    .WithMany(b => b.Loads)
            //    .HasForeignKey(ba => ba.DriverId);
            //builder.Entity<Driver>().HasOne(ba => ba.Driver)
            //    .WithMany(a => a.BookAuthors)
            //    .HasForeignKey(ba => ba.AuthorId);

            //seed data
            //builder.ApplyConfiguration(new SeedDriverData());
            //builder.ApplyConfiguration(new SeedLoadData());
            builder.ApplyConfiguration(new SeedBrokerData());

           
        }


    }
}
