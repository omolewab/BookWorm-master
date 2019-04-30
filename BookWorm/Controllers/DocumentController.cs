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
            var model = new NewDocumentViewModel
            {
                DFormats = _context.DFormats.ToList(),
                BookTypes = _context.BookTypes.ToList()
            };
            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewDocumentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.DFormats = _context.DFormats.ToList();
                return View("Create", viewModel);
            }
            if (!ModelState.IsValid)
            { 

                viewModel.BookTypes = _context.BookTypes.ToList();
                return View("Create", viewModel);
            }

            var DFormat = _context.DFormats.Single(t => t.Id == viewModel.FormatId);
            var BookType = _context.BookTypes.Single(t => t.Id == viewModel.BookTypeId);



            var document = new Documents
            {
                DName = viewModel.Name,
                DAuthor = viewModel.Author,
                DExcerpt = viewModel.Excerpt,
                DFormat = DFormat,
                BookType = BookType
            };


            _context.Documents.Add(document);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
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

        //if (ModelState.IsValid)
        //{
        //    if (file.File != null && file.File.ContentLength > 0 && file.File.ContentType == "application/pdf")
        //    {
        //        // Convert file to byte[] and upload
        //        // ...
        //        ViewBag.Message = "File Uploaded Successfully";
        //    }
        //    else
        //    {
        //        ViewBag.Message = "File Not Uploaded";
        //    }
        //}

        //return View();
    }

}

//   try
//                {
//                    string path = Path.Combine(Server.MapPath("~/Uploads"), Path.GetFileName(file.FileName));
//file.SaveAs(path);
//                    ViewBag.Message = "File uploaded successfully";
//                }
//                catch (Exception ex)
//                {
//                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
//                }
//            else
//            {
//                ViewBag.Message = "You have not specified a file.";
//            if (file != null && file.ContentLength > 0)
//                try
//                {
//                    string path = Path.Combine(Server.MapPath("~/Uploads"), Path.GetFileName(file.FileName));
//file.SaveAs(path);
//                    ViewBag.Message = "File uploaded successfully";
//                }
//                catch (Exception ex)
//                {
//                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
//                }
//            else
//            {
//                ViewBag.Message = "You have not specified a file.";
//            }
//            return View();  }
// Initialization.  
//FileViewModel model = new FileViewModel { FileAttach = null, Uploads = new List<Upload>() };

//            try
//            {
//                // Settings.  
//                model.Uploads = this._context.Uploads.Select(p => new Upload
//                {
//                    Id = p.Id,
//                    ImageName = p.ImageName,
//                    ImagePath = p.ImagePath
//                }).ToList();
//            }
//            catch (Exception ex)
//            {
//                // Info  
//                Console.Write(ex);
//            }

//            // Info. 