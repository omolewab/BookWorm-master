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
        public ActionResult Upload()
        {
            return View();
        }

        void GetFormatList()
        {
            List<Format> formats = _context.Formats.ToList();
            SelectList formatList = new SelectList(formats, "Id", "FileFormat");
            ViewBag.formats = formatList;
        }

        void GetCategoryList()
        {
            List<Category> categories = _context.Categories.ToList();
            SelectList categoryList = new SelectList(categories, "Id", "Categories");
            ViewBag.categories = categoryList;
        }

        [Authorize]
        // GET: Document
        public ActionResult Create()
        {

            GetFormatList();
            GetCategoryList();

            return View(new NewDocumentViewModel());
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewDocumentViewModel viewModel, List<HttpPostedFileBase> docs)
        {
            if (!ModelState.IsValid)
            {
                GetFormatList();
                GetCategoryList();

                return View("Create", viewModel);
            }

            var FormatId = _context.Formats.Single(t => t.Id == viewModel.FormatId).Id;
            var CategoryId = _context.Categories.Single(c => c.Id == viewModel.CategoryId).Id;


            foreach (var file in docs)
            {
                if (file != null && file.ContentLength > 0)
                    try
                    {
                        string path = Path.Combine(Server.MapPath("~/Uploads"),
                                                   Path.GetFileName(file.FileName));
                        file.SaveAs(path);

                        ViewBag.Message = "File uploaded successfully";

                        var upload = new Upload
                        {
                            ImageName = file.FileName,
                            ImagePath = path
                        };
                        _context.Uploads.Add(upload);

                        var document = new Documents
                        {
                            Name = viewModel.Name,
                            Author = viewModel.Author,
                            Excerpt = viewModel.Excerpt,
                            FormatID = FormatId,
                            CategoryID = CategoryId,
                            UploadID = upload.UploadID

                        };

                        _context.Documents.Add(document);
                        _context.SaveChanges();

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