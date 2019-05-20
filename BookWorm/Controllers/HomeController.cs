using BookWorm.Models;
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
            var AppUser = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var newDocuments = _context.Documents;


            return View(newDocuments);
        }

        public ActionResult Edit(int Id)
        {

            return View();

        }
    }
}