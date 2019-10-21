using SampleProject.Context;
using SampleProject.Helpers;
using SampleProject.Models;
using SampleProject.Repository;
using SampleProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleProject.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class VehicleController : Controller
    {
        private readonly VehicleService _vehicleService;

        public VehicleController(VehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetAllVehicles()
        {
            List<VehicleModelView> model = _vehicleService.GetAllVehicles();
            return Json(new { data = model });
        }

        public ActionResult Create()
        {
            VehicleModelView model = new VehicleModelView();
            ViewBag.VehicleTypes = _vehicleService.SelectListVehicleTypes();
            ViewBag.ManufacturerList = _vehicleService.SelectListManufacturer();
            return PartialView("_Create", model);
        }

        [HttpPost]
        public JsonResult Create(VehicleModelView model)
        {
            if (ModelState.IsValid)
            {
                bool result =_vehicleService.Add(model);
                return Json(new { data = result });
            }
            return Json(new { errors = HelperFunctionality.GetModelStateErrors(ModelState) });
        }

    }
}