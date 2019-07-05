using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bostream.Controllers
{
    public class ContactController : Controller
    {
        /// <summary>
        /// Muestra datos de un contacto.
        /// </summary>
        /// <returns>Vista de un contacto.</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}