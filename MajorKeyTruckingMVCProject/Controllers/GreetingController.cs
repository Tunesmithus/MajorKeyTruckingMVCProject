using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MajorKeyTruckingMVCProject.Controllers
{
    public class GreetingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
