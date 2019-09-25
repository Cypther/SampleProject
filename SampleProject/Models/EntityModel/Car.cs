using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleProject.Models.EntityModel
{
    public class Car : Vehicle
    {
        public string EngineType { get; set; }
        public int TrunkSize { get; set; }
    }
}