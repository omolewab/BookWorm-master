using BookWorm.Models;
using BookWorm.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookWorm.Controllers
{
    public class DocumentController : Controller
    {
        private BookWormContext _context;

        public DocumentController()
            {
            _context = new BookWormContext();
        }
        [Authorize]
        [Authorize(Roles = "Admin")]
        public ActionResult Upload ()
        {
            return View();
        }
        [Authorize]
        // GET: Document
        public ActionResult Create()
        {
            var model = new NewDocumentViewModel
            {
                Formats = _context.Formats.ToList(),
                Categories = _context.Categories.ToList()
            };
            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(NewDocumentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Formats = _context.Formats.ToList();
                return View("Create", viewModel);
            }
            if (!ModelState.IsValid)
            { 

                viewModel.Categories = _context.Categories.ToList();
                return View("Create", viewModel);
            }

            var Format = _context.Formats.Single(t => t.Id == viewModel.FormatId);
            var Categories = _context.Categories.Single(t => t.Id == viewModel.CategoriesId);



            var document = new Documents
            {
                Name = viewModel.Name,
                Author = viewModel.Author,
                Excerpt = viewModel.Excerpt,
                Format = Format,
                Categories = Categories
            };


            _context.Documents.Add(document);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult UploadsPartialView()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult UploadsPartialView(HttpPostedFile file)
        {

            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Uploads"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }

            return View();

        }
        
      
    }

}

