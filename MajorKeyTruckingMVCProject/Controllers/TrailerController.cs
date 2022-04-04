using MajorKeyTrucking.Data.Models;
using MajorKeyTrucking.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MajorKeyTruckingMVCProject.Controllers
{
    public class TrailerController : Controller
    {
        private ITrailerRepository db;

        public TrailerController(ITrailerRepository db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var model = db.GetAll().OrderBy(t => t.TrailerId);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Trailer trailer)
        {
            if (ModelState.IsValid)
            {
                db.Add(trailer);
                return RedirectToAction("Details", new { id = trailer.TrailerId });
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var trailer = db.Get(id);
            if (trailer == null)
            {
                return RedirectToAction("NotFound");
            }
            return View(trailer);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var trailer = db.Get(id);
            if (trailer == null)
            {
                return View("NotFound");
            }

            return View(trailer);
        }

        [HttpPost]
        public IActionResult Edit(Trailer trailer)
        {
            if (ModelState.IsValid)
            {
                db.Update(trailer);
                return RedirectToAction("Details", new { id = trailer.TrailerId });
            }
            return View(trailer);
            
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var trailer = db.Get(id);
            if (trailer == null)
            {
                return RedirectToAction("NotFound");
            }
            return View(trailer);
        }

        [HttpPost]

        public IActionResult Delete(int id, IFormCollection formCollection)
        {
            db.Delete(id);
            return RedirectToAction("Index");

        }


    }
}
