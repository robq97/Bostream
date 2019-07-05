using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bostream.Controllers
{
    public class WorkController : Controller
    {
        /// <summary>
        /// Llama a método de la galería del portafolio de trabajos de Bostream.
        /// </summary>
        /// <returns>Vista del portafolio de trabajos.</returns>
        public ActionResult WorkGallery()
        {
            return View();
        }
    }
}