using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bostream.Controllers
{
    public class ServiceController : Controller
    {
        /// <summary>
        /// Muestra listado de servicios ofrecidos por Bostream.
        /// </summary>
        /// <returns>Vista de los servicios.</returns>
        public ActionResult ServiceList()
        {
            return View();
        }
    }
}