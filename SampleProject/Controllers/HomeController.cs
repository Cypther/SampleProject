using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Redirecting to Vehicle controller 
            return RedirectToAction("Index", "Vehicle");
        }
    }
}