using SampleProject.Migrations;
using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SampleProject.Context
{
    public class SampleContext : DbContext
    {

        public SampleContext() : base("SampleContext")
        {
            //Database.SetInitializer(new VehicleDBInitializer());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SampleContext, Configuration>());
        }  

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
    }
}