using MajorKeyTrucking.Data;
using MajorKeyTruckingMVCProject.Data.DTOs;
using MajorKeyTruckingMVCProject.DataLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MajorKeyTruckingMVCProject.Controllers
{
    public class DriverController : Controller
    {
        private readonly IDriverRepository db;

        public DriverController(IDriverRepository db)
        {
            this.db = db;
        }

        ////public ViewResult List(GridDTO vals)
        ////{
        ////    //get GridBuilder object, load route segment values, store in seesioon
        ////    string defaultSort = nameof(Driver.FirstName);
            

        ////    // create options for querying drivers
            


        ////}

        [HttpGet]
        //Renders table
        public IActionResult Index()
        {
            var model = db.GetAll().OrderBy(n => n.DriverId);
            return View(model);
        }

        [HttpGet]
        //Details of Entry
        public IActionResult Details(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            
            return View(model);
        }

        [HttpGet]
        //Edit
        public IActionResult Create()
        {
            var driverList = db.GetAll().OrderBy(d => d.DriverId);
            ViewBag.Driver = driverList;

            var stateList = Helpers.ListHelper.GetStates().Select(s => s.Text);
            ViewBag.States = stateList;

            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Driver driver)
        {

            if (ModelState.IsValid)
            {
                db.Add(driver);

                return RedirectToAction("Details", new { id = driver.DriverId });
            }

            return View();

        }

        [HttpGet]
        //Edit
        public IActionResult Edit(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }

            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        //Edit
        public IActionResult Edit(Driver driver)
        {
            if (ModelState.IsValid)
            {
                db.Update(driver);
                return RedirectToAction("Details", new { id = driver.DriverId });
            }
            return View(driver);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }






    }
}
