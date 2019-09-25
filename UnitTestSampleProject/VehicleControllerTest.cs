using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using SampleProject;
using SampleProject.Controllers;
using SampleProject.Context;
using SampleProject.Service;
using SampleProject.Repository;
using SampleProject.Models;
using SampleProject.Helpers;

namespace UnitTestSampleProject
{
    [TestClass]
    public class VehicleControllerTest
    {
        [TestMethod]
        public void Index()
        {
            //Arrange
            SampleContext sampleContext = new SampleContext();
            VehicleRepository vehicleRepository = new VehicleRepository(sampleContext);
            VehicleService vehicleService = new VehicleService(vehicleRepository);
            VehicleController vehicleController = new VehicleController(vehicleService);

            //Act
            ViewResult result = vehicleController.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAllVehicles()
        {
            //Arrange
            SampleContext sampleContext = new SampleContext();
            VehicleRepository vehicleRepository = new VehicleRepository(sampleContext);
            VehicleService vehicleService = new VehicleService(vehicleRepository);
            VehicleController vehicleController = new VehicleController(vehicleService);

            //Act
            JsonResult result = vehicleController.GetAllVehicles();

            //Assert
            Assert.IsNotNull(result.Data);
        }

        [TestMethod]
        public void Create()
        {
            //Arrange
            SampleContext sampleContext = new SampleContext();
            VehicleRepository vehicleRepository = new VehicleRepository(sampleContext);
            VehicleService vehicleService = new VehicleService(vehicleRepository);
            VehicleController vehicleController = new VehicleController(vehicleService);

            VehicleModelView model = new VehicleModelView()
            {
                VehicleModel = "IS 350",
                Color = "Silver",
                Year = "2019",
                ManufacturerId = 7,
                Name = "Lexus",
                VehicleType = AppConstants.VehicleType.Car,
                TrunkSize = 10,
                EngineType = "V6"
            };

            //Act
            JsonResult result = vehicleController.Create(model);

            //Assert
            Assert.AreEqual("{ data = True }", result.Data.ToString());
        }
    }
}
