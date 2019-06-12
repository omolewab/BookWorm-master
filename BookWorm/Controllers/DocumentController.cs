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
        public ActionResult Create(NewDocumentViewModel viewModel, List<HttpPostedFileBase> docs, List<HttpFileCollectionBase>thumbnails)
        {
            if (!ModelState.IsValid)
            {
                GetFormatList();
                GetCategoryList();

                return View("Create", viewModel);
            }

            var FormatId = _context.Formats.Single(t => t.Id == viewModel.FormatID).Id;
            var CategoryId = _context.Categories.Single(c => c.Id == viewModel.CategoryID).Id;


            //foreach (var file in docs)
            //{
            var file = docs[0];
            var thumbnail = docs[1];
                if (file != null && file.ContentLength > 0)
                    try
                    {
                        string path = Path.Combine(Server.MapPath("~/Uploads"),
                                                   Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                
                        string thumb = Path.Combine(Server.MapPath("~/Thumbnails"), 
                                                    Path.GetFileName(thumbnail.FileName));

                        thumbnail.SaveAs(thumb);

                        var upload = new Upload
                        {
                            ImageName = file.FileName,
                            ImagePath = path,
                            ThumbnailPath = thumb
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

            //}

            return RedirectToAction("AfterLogin", "Home");
        }

      
        public ActionResult Edit(int Id)
        {
            ViewBag.id = Id;
            GetFormatList();
            GetCategoryList();

            return View();
        }

        public ActionResult EditDocument(int Id)
        {

            TempData["id"] = Id;
            Documents document = _context.Documents.
                Include(g => g.Category)
                .Include(f => f.Format)
                .SingleOrDefault(p => p.DocumentsID == Id);


            
            var model_ = new NewDocumentViewModel
            {
                Name = document.Name,
                Author = document.Author,
                Excerpt = document.Excerpt,
                FormatID = document.Format.Id,
                CategoryID = document.Category.Id,
            };
            return PartialView(model_);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDocument(NewDocumentViewModel viewModel)
        {
            var pId = (int)TempData["id"];
            Documents document = _context.Documents.SingleOrDefault(r => r.DocumentsID == pId);


            if (ModelState.IsValid)
            {
                document.Name = viewModel.Name;
                document.Author = viewModel.Author;
                document.Excerpt = viewModel.Excerpt;
                document.Format = _context.Formats.FirstOrDefault(f => f.Id == viewModel.FormatID);
                document.Category = _context.Categories.FirstOrDefault(c => c.Id == viewModel.CategoryID);

                _context.Entry(document).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("AfterLogin", "Home");

        }

        public ActionResult Delete(int? Id)
        {
            ViewBag.id = Id;

            Documents document = _context.Documents
                .Include(p => p.Category)
                .Include(p => p.Format)
                .Include(d => d.Uploads)
                .SingleOrDefault(p => p.DocumentsID == Id);

            _context.Uploads.Remove(document.Uploads);
            _context.Documents.Remove(document);

            _context.SaveChanges();

            return RedirectToAction("AfterLogin", "Home");

        }

        //public ActionResult Download()
        //{
        //    string path = Server.MapPath("~/Uploads/");
        //    DirectoryInfo directoryInfo = new DirectoryInfo(path);
        //    FileInfo[] file = directoryInfo.GetFiles("*.*");
        //    List<string> list = new List<string>(file.Length);
        //    foreach (var document in file)
        //    {
        //        list.Add(document.Name);
        //    }
        //    return View(list);
        //}

        //public ActionResult DownloadDocument(string filename)
        //{
        //    if (Path.GetExtension(filename) == ".pdf")
        //    {
        //        string ImagePath = Path.Combine(Server.MapPath("~/Uploads/"), filename);
        //        return File(ImagePath, "Documents/pdf");
        //    }
        //    else
        //    {
        //        return new HttpStatusCodeResult(System.Net.HttpStatusCode.Forbidden);
        //    }
        //}

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
//public ActionResult UploadsPartialView()
//{
//    return PartialView("UploadsPartialView");
//}
//[HttpPost]
//public ActionResult UploadsPartialView(List<HttpPostedFileBase> docs)
//{
//    //var file = docs.FirstOrDefault();


//    return View();

//}