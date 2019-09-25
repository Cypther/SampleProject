using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Repository
{
    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> GetAllVehicles();
        IEnumerable<Manufacturer> GetAllManufacturers();
        Vehicle GetById(int VehicleId);
        bool Add(Vehicle vehicle);
        bool Update(Vehicle vehicle);
        bool Delete(int vehicleId);
        void Save(Vehicle vehicle);
    }
}
