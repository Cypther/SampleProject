using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using SampleProject.Controllers;
using SampleProject.Context;
using SampleProject.Service;
using SampleProject.Repository;
using SampleProject.Models;
using SampleProject.Helpers;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using SampleProject.Models.EntityModel;

namespace UnitTestSampleProject
{
    [TestClass]
    public class VehicleRepositoryTest
    {
        [TestMethod]
        public void GetAllVehicles()
        {
            //Arrange
            SampleContext sampleContext = new SampleContext();
            VehicleRepository vehicleRepository = new VehicleRepository(sampleContext);

            //Act
            IEnumerable<Vehicle> result = vehicleRepository.GetAllVehicles();

            //Assert
            Assert.IsTrue(result.Count() > 1, "The collection was not greater than 1");
        }

        [TestMethod]
        public void GetAllManufacturers()
        {
            //Arrange
            SampleContext sampleContext = new SampleContext();
            VehicleRepository vehicleRepository = new VehicleRepository(sampleContext);

            //Act
            IEnumerable<Manufacturer> result = vehicleRepository.GetAllManufacturers();

            //Assert
            Assert.IsTrue(result.Count() > 1, "The collection was not greater than 1");
        }

        [TestMethod]
        public void GetById()
        {
            //Arrange
            SampleContext sampleContext = new SampleContext();
            VehicleRepository vehicleRepository = new VehicleRepository(sampleContext);

            //Act
            Vehicle result = vehicleRepository.GetById(1);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Add()
        {
            //Arrange
            SampleContext sampleContext = new SampleContext();
            VehicleRepository vehicleRepository = new VehicleRepository(sampleContext);

            Car car = new Car()
            {
                Model = "M3",
                Color = "Red",
                Year = "2019",
                VehicleType = AppConstants.VehicleType.Car,
                ManufacturerId = 3,
                EngineType = "V8",
                TrunkSize = 20
            };

            //Act
            bool result = vehicleRepository.Add(car);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Update()
        {
            //Arrange
            SampleContext sampleContext = new SampleContext();
            VehicleRepository vehicleRepository = new VehicleRepository(sampleContext);

            Vehicle vehicle = vehicleRepository.GetById(1);
            vehicle.Color = "Pink";

            //Act
            bool result = vehicleRepository.Update(vehicle);

            //Assert
            Assert.IsTrue(result);
        }
    }
}
