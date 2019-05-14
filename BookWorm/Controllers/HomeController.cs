using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookWorm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
    }
}