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
        public ActionResult Upload ()
        {
            return View();
        }
        [Authorize]
        // GET: Document
        public ActionResult Create()
        {
           
            List<Format> formats = _context.Formats.ToList();
            SelectList formatList = new SelectList(formats,"Id","FileFormat");
            ViewBag.formats = formatList;
         

            List<Category> categories = _context.Categories.ToList();
            SelectList categoryList = new SelectList(categories, "Id", "Categories");
            ViewBag.categories = categoryList;



            return View(new NewDocumentViewModel());
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewDocumentViewModel viewModel, List<HttpPostedFileBase> docs)
        {
            if (!ModelState.IsValid)
            {
                List<Format> formats = _context.Formats.ToList();
                SelectList formatList = new SelectList(formats, "Id", "FileFormat");
                ViewBag.formats = formatList;


                List<Category> categories = _context.Categories.ToList();
                SelectList categoryList = new SelectList(categories, "Id", "Categories");
                ViewBag.categories = categoryList;
               
                return View("Create", viewModel);
            }

           


            var Format = _context.Formats.Single(t => t.Id == viewModel.FormatId);
            var Category = _context.Categories.Single(c => c.Id == viewModel.CategoryId);



            var document = new Documents
            {
                Name = viewModel.Name,
                Author = viewModel.Author,
                Excerpt = viewModel.Excerpt,
                Format = Format,
                Category = Category,
                Uploads = new Upload
                {
                    ImageName = viewModel.ImageName,
                    ImagePath = viewModel.ImagePath
                }
                
            };

            foreach (var file in docs)
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
            }



            _context.Documents.Add(document);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult UploadsPartialView()
        {
            return PartialView("UploadsPartialView");
        }
        [HttpPost]
        public ActionResult UploadsPartialView(List<HttpPostedFileBase> docs)
        {
            //var file = docs.FirstOrDefault();
           

            return View();

        }
        
      
    }

}

//if (!ModelState.IsValid)
//{

//    viewModel.Categories = _context.Categories.ToList();
//    return View("Create", viewModel);
//}

//var model = new NewDocumentViewModel();
//{
//    Formats = _context.Formats.ToList(),
//    Categories = _context.Categories.ToList()
//};
//permit a shortcut