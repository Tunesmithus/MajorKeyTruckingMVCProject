using MajorKeyTrucking.Data;
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
    public class ExpenseController : Controller
    {
        private IExpenseRepository db;
        private IDriverRepository driverRepository;
        private ITrailerRepository trailerRepository;
        private ITruckRepository truckRepository;
        private IBrokerRepository brokerRepository;

        public ExpenseController(IExpenseRepository db, IDriverRepository driverRepository, 
            ITrailerRepository trailerRepository, ITruckRepository truckRepository, IBrokerRepository brokerRepository )
        {
            this.driverRepository = driverRepository;
            this.trailerRepository = trailerRepository;
            this.truckRepository = truckRepository;
            this.brokerRepository = brokerRepository;
            
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {


            var model = db.GetAll().OrderBy(n => n.ExpenseId);
            return View(model);

        }

        [HttpGet]

        public IActionResult Create()
        {

            var drivers = driverRepository.GetAll().OrderBy(d => d.DriverId);
            ViewBag.DriverList = drivers;

            var trailers = trailerRepository.GetAll().OrderBy(t => t.TrailerId);
            ViewBag.TrailerList = trailers;

            var trucks = truckRepository.GetAll().OrderBy(t => t.TruckId);
            ViewBag.TruckList = trucks;

            var brokers = brokerRepository.GetAll().OrderBy(b => b.BrokerId);
            ViewBag.BrokerList = brokers;

            return View();
        }

        [HttpPost]

        public IActionResult Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                db.Add(expense);
                return RedirectToAction("Details", new { id = expense.ExpenseId });
            }

            return View();

        }

        [HttpGet]

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
        public IActionResult Edit(Expense expense)
        {
            if (ModelState.IsValid)
            {
                db.Update(expense);
                return RedirectToAction("Details", new { id = expense.ExpenseId });
            }
            return View(expense);
        }

        [HttpGet]

        public IActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return RedirectToAction("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id, IFormCollection form)
        {
           
                db.Delete(id);
                return RedirectToAction("Index");
            
        }
    }
}
