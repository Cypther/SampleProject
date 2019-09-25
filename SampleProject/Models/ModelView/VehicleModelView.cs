using SampleProject.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static SampleProject.Helpers.AppConstants;

namespace SampleProject.Models
{
    public class VehicleModelView
    {
        public int VehicleId { get; set; }

        [Required]
        [Display(Name = "Vehicle Model")]
        public string VehicleModel { get; set; }

        [Required]
        [Display(Name = "Vehicle Color")]
        public string Color { get; set; }

        [Required]
        [Display(Name = "Vehicle Year")]
        public string Year { get; set; }

        public int ManufacturerId { get; set; }

        [Required]
        [Display(Name = "Manufacturer Name")]
        public string Name { get; set; }

        [Display(Name = "Vehicle Type")]
        public VehicleType VehicleType { get; set; }

        [Display(Name = "Trunk Size")]
        public int TrunkSize { get; set; }

        [Display(Name = "Engine Type")]
        public string EngineType { get; set; }

        [Display(Name = "Cargo Size")]
        public int CargoSize { get; set; }

        [Display(Name = "Towing Capabilities")]
        public int TowingCapabilities { get; set; }

        [Display(Name = "Saddle Height")]
        public int SaddleHeight { get; set; }
    }
}