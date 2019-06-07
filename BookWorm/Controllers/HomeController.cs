﻿using BookWorm.Models;
using BookWorm.ViewModels;
using System;
using System.Collections.Generic;
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
            ViewBag.Message = "Search and Browse Documents";

            return View();
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

            return View(model);
        }
        public ActionResult AfterLogin()
        {
            List<DocumentViewModel> documentVMs = new List<DocumentViewModel>();
            var AppUser = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var newDocuments = _context.Documents.ToList();
            var newUploads = _context.Uploads.ToList();


            string uri = string.Format("{0}://{1}", Request.Url.Scheme, Request.Url.Authority);


            foreach (var doc in newDocuments)
            {
                DocumentViewModel viewModel = new DocumentViewModel
                {
                    Name = doc.Name,
                    Excerpt = doc.Excerpt,
                    ThumbnailUrl = doc.Uploads.ThumbnailPath
                };

                documentVMs.Add(viewModel);
                string tni = (uri + "/Thumbnails/" + doc.Substring(doc.LastIndexOf("\\") + 1));
            }
            


            return View(documentVMs);
        }

        public ActionResult Edit(int Id)
        {

            return View();

        }
    }
}