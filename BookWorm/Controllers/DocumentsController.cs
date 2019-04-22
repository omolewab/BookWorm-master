using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookWorm.Controllers
{
    public class DocumentsController : Controller
    {
        // GET: Document
        public ActionResult Create()
        {
            return View();
        }
    }
}