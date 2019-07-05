using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bostream.Controllers
{
    public class TaskController : Controller
    {
        /// <summary>
        /// Muestra información de tarea asignada a un contacto.
        /// </summary>
        /// <returns>Vista de datos de una tarea.</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}