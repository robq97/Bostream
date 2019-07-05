using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bostream.Controllers
{
    public class InformationController : Controller
    {
        /// <summary>
        /// Muestra formulario de contacto.
        /// </summary>
        /// <returns>Vista de formulario de contacto.</returns>
        public ActionResult InformationForm()
        {
            return View();
        }
    }
}