using SampleProject.Helpers;
using SampleProject.Models;
using SampleProject.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SampleProject.Context
{
    public class VehicleDBInitializer : CreateDatabaseIfNotExists<SampleContext>
    {
        protected override void Seed(SampleContext context)
        {
            IList<Manufacturer> ManufacturerData = new List<Manufacturer>();

            ManufacturerData.Add(new Manufacturer() { Name = "Mercedes-Benz" });
            ManufacturerData.Add(new Manufacturer() { Name = "Porsche" });
            ManufacturerData.Add(new Manufacturer() { Name = "BMW" });
            ManufacturerData.Add(new Manufacturer() { Name = "Ferrari" });
            ManufacturerData.Add(new Manufacturer() { Name = "Aston Martin" });
            ManufacturerData.Add(new Manufacturer() { Name = "Rolls-Royce" });
            ManufacturerData.Add(new Manufacturer() { Name = "Toyota" });
            ManufacturerData.Add(new Manufacturer() { Name = "Bugatti" });
            ManufacturerData.Add(new Manufacturer() { Name = "Maserati" });
            ManufacturerData.Add(new Manufacturer() { Name = "Honda" });
            ManufacturerData.Add(new Manufacturer() { Name = "Ford" });
            ManufacturerData.Add(new Manufacturer() { Name = "Volvo Cars" });
            ManufacturerData.Add(new Manufacturer() { Name = "Lexus" });
            ManufacturerData.Add(new Manufacturer() { Name = "Bentley Motors Limited" });
            ManufacturerData.Add(new Manufacturer() { Name = "Volkswagen" });

            context.Manufacturers.AddRange(ManufacturerData);
            context.SaveChanges();

            IList<Vehicle> VehicleData = new List<Vehicle>();

            VehicleData.Add(new Car()
            {
                Model = "Camry",
                Color = "Red",
                Year = "2015",
                VehicleType = AppConstants.VehicleType.Car,
                ManufacturerId = context.Manufacturers.FirstOrDefault(x => x.Name == "Toyota").ManufacturerId,
                EngineType = "V6",
                TrunkSize = 15
            });

            VehicleData.Add(new Car()
            {
                Model = "Jetta",
                Color = "White",
                Year = "2013",
                VehicleType = AppConstants.VehicleType.Car,
                ManufacturerId = context.Manufacturers.FirstOrDefault(x => x.Name == "Volkswagen").ManufacturerId,
                EngineType = "V6",
                TrunkSize = 9
            });

            VehicleData.Add(new Car()
            {
                Model = "Civic",
                Color = "Black",
                Year = "2017",
                VehicleType = AppConstants.VehicleType.Car,
                ManufacturerId = context.Manufacturers.FirstOrDefault(x => x.Name == "Honda").ManufacturerId,
                EngineType = "V6",
                TrunkSize = 12
            });

            VehicleData.Add(new Truck()
            {
                Model = "F-150",
                Color = "Blue",
                Year = "2018",
                VehicleType = AppConstants.VehicleType.Truck,
                ManufacturerId = context.Manufacturers.FirstOrDefault(x => x.Name == "Ford").ManufacturerId,
                CargoSize = 450,
                TowingCapabilities = 800
            });

            VehicleData.Add(new Truck()
            {
                Model = "Tundra",
                Color = "White",
                Year = "2019",
                VehicleType = AppConstants.VehicleType.Truck,
                ManufacturerId = context.Manufacturers.FirstOrDefault(x => x.Name == "Toyota").ManufacturerId,
                CargoSize = 430,
                TowingCapabilities = 700
            });

            VehicleData.Add(new Motorcycle()
            {
                Model = "Tundra",
                Color = "White",
                Year = "2019",
                VehicleType = AppConstants.VehicleType.Motorcycle,
                ManufacturerId = context.Manufacturers.FirstOrDefault(x => x.Name == "Toyota").ManufacturerId,
                SaddleHeight = 86
            });

            context.Vehicles.AddRange(VehicleData);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}