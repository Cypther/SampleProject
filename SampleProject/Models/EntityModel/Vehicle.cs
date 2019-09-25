using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static SampleProject.Helpers.AppConstants;

namespace SampleProject.Models
{
    public abstract class Vehicle
    {
        public int VehicleId { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Year { get; set; }
        public VehicleType VehicleType { get; set; }

        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}