using SampleProject.Context;
using SampleProject.Helpers;
using SampleProject.Models;
using SampleProject.Models.EntityModel;
using SampleProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleProject.Service
{
    public class VehicleService
    {
        private readonly VehicleRepository _vehicleRepository;

        public VehicleService(VehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public bool Add(VehicleModelView vehicleModelView)
        {
            bool result = false;
            if (vehicleModelView.VehicleType == AppConstants.VehicleType.Car)
            {
                result = _vehicleRepository.Add(new Car()
                {
                    Model = vehicleModelView.VehicleModel,
                    Color = vehicleModelView.Color,
                    Year = vehicleModelView.Year,
                    VehicleType = vehicleModelView.VehicleType,
                    ManufacturerId = vehicleModelView.ManufacturerId,
                    EngineType = vehicleModelView.EngineType,
                    TrunkSize = vehicleModelView.TrunkSize
                });
            }

            if (vehicleModelView.VehicleType == AppConstants.VehicleType.Truck)
            {
                result = _vehicleRepository.Add(new Truck()
                {
                    Model = vehicleModelView.VehicleModel,
                    Color = vehicleModelView.Color,
                    Year = vehicleModelView.Year,
                    VehicleType = vehicleModelView.VehicleType,
                    ManufacturerId = vehicleModelView.ManufacturerId,
                    CargoSize = vehicleModelView.CargoSize,
                    TowingCapabilities = vehicleModelView.TowingCapabilities
                });
            }

            if (vehicleModelView.VehicleType == AppConstants.VehicleType.Motorcycle)
            {
                result = _vehicleRepository.Add(new Motorcycle()
                {
                    Model = vehicleModelView.VehicleModel,
                    Color = vehicleModelView.Color,
                    Year = vehicleModelView.Year,
                    VehicleType = vehicleModelView.VehicleType,
                    ManufacturerId = vehicleModelView.ManufacturerId,
                    SaddleHeight = vehicleModelView.SaddleHeight
                });
            }
            return result;
        }

        public List<VehicleModelView> GetAllVehicles()
        {
            IEnumerable<Vehicle> VehicleList = _vehicleRepository.GetAllVehicles();
            List<VehicleModelView> VehicleModelViewList = new List<VehicleModelView>();

            foreach (Vehicle Vehicle in VehicleList)
            {
                if (Vehicle is Car car)
                {
                    VehicleModelViewList.Add(new VehicleModelView()
                    {
                        VehicleId = car.VehicleId,
                        VehicleModel = car.Model,
                        Color = car.Color,
                        Year = car.Year,
                        ManufacturerId = car.ManufacturerId,
                        Name = car.Manufacturer.Name,
                        VehicleType = car.VehicleType,
                        TrunkSize = car.TrunkSize,
                        EngineType = car.EngineType
                    });
                }

                if (Vehicle is Truck tuck)
                {
                    VehicleModelViewList.Add(new VehicleModelView()
                    {
                        VehicleId = tuck.VehicleId,
                        VehicleModel = tuck.Model,
                        Color = tuck.Color,
                        Year = tuck.Year,
                        ManufacturerId = tuck.ManufacturerId,
                        Name = tuck.Manufacturer.Name,
                        VehicleType = tuck.VehicleType,
                        CargoSize = tuck.CargoSize,
                        TowingCapabilities = tuck.TowingCapabilities
                    });
                }

                if (Vehicle is Motorcycle motorcycle)
                {
                    VehicleModelViewList.Add(new VehicleModelView()
                    {
                        VehicleId = motorcycle.VehicleId,
                        VehicleModel = motorcycle.Model,
                        Color = motorcycle.Color,
                        Year = motorcycle.Year,
                        ManufacturerId = motorcycle.ManufacturerId,
                        Name = motorcycle.Manufacturer.Name,
                        VehicleType = motorcycle.VehicleType,
                        SaddleHeight = motorcycle.SaddleHeight
                    });
                }
            }
            return VehicleModelViewList;
        }

        public List<SelectListItem> SelectListVehicleTypes()
        {

            List<SelectListItem> vehicleTypes = Enum.GetValues(typeof(AppConstants.VehicleType)).Cast<AppConstants.VehicleType>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList();

            return vehicleTypes;
        }

        public List<SelectListItem> SelectListManufacturer()
        {
            IEnumerable<Manufacturer> ManufacturerList = _vehicleRepository.GetAllManufacturers();
            List<SelectListItem> SelectListManufacturer = ManufacturerList.Select(v => new SelectListItem
            {
                Value = v.ManufacturerId.ToString(),
                Text = v.Name
            }).ToList();

            return SelectListManufacturer;
        }
    }
}