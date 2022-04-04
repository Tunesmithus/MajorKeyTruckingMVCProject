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
    public class BrokerController : Controller
    {
        private IBrokerRepository db;

        public BrokerController(IBrokerRepository db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Broker broker)
        {

            if (ModelState.IsValid)
            {
                db.Add(broker);
                return RedirectToAction("Details", new { id = broker.BrokerId });

            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return RedirectToAction("NotFound");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return RedirectToAction("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Broker broker)
        {
            if (ModelState.IsValid)
            {
                db.Update(broker);
                return RedirectToAction("Details", new { id = broker.BrokerId });
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return RedirectToAction("NotFound");

            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id, IFormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
