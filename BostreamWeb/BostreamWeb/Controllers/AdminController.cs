using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bostream.Controllers
{
    public class AdminController : Controller
    {
        /// <summary>
        /// Ingresa como un usuario Admin.
        /// </summary>
        /// <returns>Vista de login para admins.</returns>
        public ActionResult LogIn()
        {
            return View();
        }
    }
}