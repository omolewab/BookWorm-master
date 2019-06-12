using BookWorm.Models;
using BookWorm.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookWorm.Controllers
{
    public class HomeController : Controller
    {
        private BookWormContext _context;

        //Instance of the Database (_context)
        public HomeController()
        {
            _context = new BookWormContext();
        }
        public ActionResult Index()
        {
            ViewBag.IsHome = true;
            if (User != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("AfterLogin");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Category()
        {
            List<CategoryViewModel> categoryVMs = new List<CategoryViewModel>();
            var newCategory = _context.Categories.ToList();

            return View(categoryVMs);
        }
        public ActionResult MyList()
        {
            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }

        public ActionResult Search(string q)
        {
            //q = "few random words" (no need to remove '+' signs) 
            var model = q;

            List<DocumentViewModel> documentVMs = new List<DocumentViewModel>();
            var AppUser = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var newDocuments = _context.Documents.Include("Uploads").Where(d => d.Author.Contains(q)||d.Name.Contains(q)).ToList();


            foreach (var docs in newDocuments)
            {
                var thumbNail = "~/Thumbnails/" + docs.Uploads.ThumbnailPath.Substring(docs.Uploads.ThumbnailPath.LastIndexOf("\\") + 1);
                var download = "~/Uploads/" + docs.Uploads.ImagePath.Substring(docs.Uploads.ImagePath.LastIndexOf("\\") + 1);


                DocumentViewModel viewModel = new DocumentViewModel
                {
                    DocumentsID = docs.DocumentsID,
                    Name = docs.Name,
                    Excerpt = docs.Excerpt,
                    ThumbnailUrl = thumbNail,
                    DownloadUrl = download
                };

                documentVMs.Add(viewModel);
            }

            return View(documentVMs);
        }

        public ActionResult AfterLogin()
        {
            List<DocumentViewModel> documentVMs = new List<DocumentViewModel>();
            var AppUser = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var newDocuments = _context.Documents.Include("Uploads").ToList();


            foreach (var docs in newDocuments)
            {
                var thumbNail = "~/Thumbnails/" + docs.Uploads.ThumbnailPath.Substring(docs.Uploads.ThumbnailPath.LastIndexOf("\\") + 1);
                var download = "~/Uploads/" + docs.Uploads.ImagePath.Substring(docs.Uploads.ImagePath.LastIndexOf("\\") + 1);


                DocumentViewModel viewModel = new DocumentViewModel
                {
                    DocumentsID = docs.DocumentsID,
                    Name = docs.Name,
                    Excerpt = docs.Excerpt,
                    ThumbnailUrl = thumbNail,
                    DownloadUrl = download
                };
                    
                documentVMs.Add(viewModel);
            }
            
            return View(documentVMs);
        }

        public ActionResult Edit(int Id)
        {

            return View();

        }
    }
}

//string tni = (uri + "/Thumbnails/" + doc.Substring(doc.LastIndexOf("\\") + 1));