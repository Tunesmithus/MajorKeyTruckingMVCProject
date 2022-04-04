using MajorKeyTrucking.Data.MockUpData;
using MajorKeyTrucking.Data.Models;
using MajorKeyTruckingMVCProject.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MajorKeyTruckingMVCProject.Helpers;
using MajorKeyTrucking.Data;
using MajorKeyTrucking.Data.Repository;
using System.IO;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iText.Layout.Properties;
using iText.Layout.Element;
using Paragraph = iTextSharp.text.Paragraph;
using iText.IO.Image;
using Image = iText.Layout.Element.Image;

namespace MajorKeyTruckingMVCProject.Controllers
{
    public class LoadController : Controller
    {
        private IDriverRepository driverRepository;
        private IBrokerRepository brokerRepository;
        private ILoadRepository db;
        private ITruckRepository truckRepository;
        private ITrailerRepository trailerRepository;

        public LoadController(ILoadRepository db, IDriverRepository driverRepository, ITruckRepository truckRepository, ITrailerRepository trailerRepository, IBrokerRepository brokerRepository)
        {
            this.truckRepository = truckRepository;
            this.trailerRepository = trailerRepository;
            this.driverRepository = driverRepository;
            this.brokerRepository = brokerRepository;
            this.db = db;
        }
        public IActionResult Index()
        {
            
            var model = db.GetAll().OrderBy(l => l.LoadId);
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
        public IActionResult Create(Load load)
        {

            if (ModelState.IsValid)
            {
                db.Add(load);
                return RedirectToAction("Details", new { id = load.LoadId});
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var drivers = driverRepository.GetAll().OrderBy(d => d.DriverId);
            ViewBag.DriverList = drivers;

            var trailers = trailerRepository.GetAll().OrderBy(t => t.TrailerId);
            ViewBag.TrailerList = trailers;

            var trucks = truckRepository.GetAll().OrderBy(t => t.TruckId);
            ViewBag.TruckList = trucks;

            var brokers = brokerRepository.GetAll().OrderBy(b => b.BrokerId);
            ViewBag.BrokerList = brokers;

            var load = db.Get(id);
            if (load == null)
            {
                return View ("NotFound");
            }
            return View(load);
        }

        [HttpPost]
        public IActionResult Edit(Load load)
        {
            if (ModelState.IsValid)
            {
                db.Update(load);
                return RedirectToAction("Details", new { id = load.LoadId });
            }
            return View(load);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var load = db.Get(id);
            if (load == null)
            {
                return View("NotFound");
            }
            return View(load);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var load = db.Get(id);
            if (load == null)
            {
                return RedirectToAction("NotFound");
            }
            return View(load);
        }

        [HttpPost]
        public IActionResult Delete(int id, IFormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }

        public FileResult CreatePDF()
        {
            
            MemoryStream workStream = new MemoryStream();
            //StringBuilder status = new StringBuilder("");
            DateTime dTime = DateTime.Now;

            ////file name to be created
            string strPDFFileName = string.Format("SamplePDF" + dTime.ToString("yyyyMMdd") + ".pdf");

            Document pdfDoc = new Document();
            pdfDoc.SetMargins(20f, 20f, 0f, 0f);

            Paragraph header = new Paragraph("List");

            //add image
            
            Image img = new iText.Layout.Element.Image(ImageDataFactory.Create(@"C:\Users\chann\OneDrive\Pictures\Screenshots\2021-12-03.png"));

            //Create PDF Table with 4 columns
            PdfPTable tableLayout = new PdfPTable(4);
            pdfDoc.SetMargins(20f, 20f, 20f, 0f);

            string path = $@"C:\Users\chann\Downloads\{strPDFFileName}";
            

            //Add content to PDF
            //PdfWriter.GetInstance(pdfDoc, new FileStream(path, FileMode.Create));
            PdfWriter.GetInstance(pdfDoc, workStream).CloseStream = false;
            
            // Open PDF
            pdfDoc.Open();

            //Add Content to Pdf

            pdfDoc.Add(header);
            pdfDoc.Add(Add_Content_To_PDF(tableLayout));
            


            // Closing the documnet 
            pdfDoc.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;

            return File(workStream, "application/pdf", strPDFFileName);

        }

        protected PdfPTable Add_Content_To_PDF(PdfPTable tableLayout)
        {
            float [] headers = { 10, 24, 24, 24}; //Header Widths
            tableLayout.SetWidths(headers); // set the pdf headers
            tableLayout.WidthPercentage = 50; // Set the pdf File width percentage
            tableLayout.HeaderRows = 1;

            ////Add Title to the PDF file at the top
            List<Load> loads = db.GetAll().ToList();

            tableLayout.AddCell(new PdfPCell(new Phrase("Creating Pdf using ItextSharp",
                new Font(Font.FontFamily.HELVETICA, 8, 1, new iTextSharp.text.BaseColor(0, 0, 0))))
            { Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_CENTER });

            //Add Header
            AddCellToHeader(tableLayout, "LoadId");
            AddCellToHeader(tableLayout, "Load Pay");
            AddCellToHeader(tableLayout, "Rate Per Mile");
            AddCellToHeader(tableLayout, "Driver Id");

            //Add Body
            foreach (var load in loads)
            {
                AddCellToBody(tableLayout, load.LoadId.ToString());
                AddCellToBody(tableLayout, load.LoadPay.ToString());
                AddCellToBody(tableLayout, load.RatePerMile.ToString());
                AddCellToBody(tableLayout, load.DriverId.ToString());

            }

            return tableLayout;


        }

        //Add to the body of table cells
        private void AddCellToBody(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255)

            });
        }

        //add to the cells of table header
        private void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(7, 8, 8, 0)
            });

        }


    }
}
