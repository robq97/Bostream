using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bostream.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Muestra vista del homepage
        /// </summary>
        /// <returns>Vista del homepage.</returns>
        public ActionResult Index()
        {
            return View();
        }

    }
}