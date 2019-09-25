using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SampleProject.Context;
using SampleProject.Models;

namespace SampleProject.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly SampleContext _context;

        public VehicleRepository(SampleContext context)
        {
            _context = context;
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return _context.Vehicles.Include(x => x.Manufacturer).ToList();
        }

        public IEnumerable<Manufacturer> GetAllManufacturers()
        {
            return _context.Manufacturers.ToList();
        }

        public Vehicle GetById(int VehicleId)
        {
            return _context.Vehicles.Find(VehicleId);
        }

        public bool Add(Vehicle vehicle)
        {
            if (vehicle != null)
            {
                _context.Vehicles.Add(vehicle);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(Vehicle vehicle)
        {
            if (vehicle != null)
            {
                _context.Entry(vehicle).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(int vehicleId)
        {
            Vehicle vehicle = _context.Vehicles.Find(vehicleId);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void Save(Vehicle vehicle)
        {
            _context.SaveChanges();
        }
    }
}