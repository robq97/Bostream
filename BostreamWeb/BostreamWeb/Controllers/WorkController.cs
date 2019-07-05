using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bostream.Controllers
{
    public class WorkController : Controller
    {
        // GET: Work
        public ActionResult WorkGallery()
        {
            return View();
        }
    }
}