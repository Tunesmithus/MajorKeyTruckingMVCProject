using MajorKeyTrucking.Data.MockUpData;
using MajorKeyTrucking.Data.Models;
using MajorKeyTrucking.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MajorKeyTruckingMVCProject.Controllers
{
    public class TruckController : Controller
    {
        private ITruckRepository db;

        public TruckController(ITruckRepository db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var model = db.GetAll().OrderBy(t => t.TruckId);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Truck truck)
        {
            if (ModelState.IsValid)
            {
                db.Add(truck);
                return RedirectToAction("Details", new { id = truck.TruckId });
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var truck = db.Get(id);
            if (truck == null)
            {
                return View("NotFound");
            }
            return View(truck);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var truck = db.Get(id);
            if (truck == null)
            {
                return View("NotFound");
            }
            return View(truck);
        }

        [HttpPost]
        public IActionResult Edit(Truck truck)
        {
            if (ModelState.IsValid)
            {
                db.Update(truck);
                return RedirectToAction("Details", new { id = truck.TruckId });
            }
            return View(truck);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var truck = db.Get(id);
            if (truck == null)
            {
                return RedirectToAction("NotFound");
            }
            return View(truck);
        }

        [HttpPost]
        public IActionResult Delete(int id, IFormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
            
        }


    }
}
