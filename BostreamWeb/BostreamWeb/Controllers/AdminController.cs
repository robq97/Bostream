using BostreamWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

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

        public ActionResult Authentication(BostreamWeb.Models.Admin adminModel)
        {
            using (BostreamEntities1 db = new BostreamEntities1())
            {
                var adminDetails = db.Admins.Where(x =>
               x.Username == adminModel.Username &&
               x.Password == adminModel.Password).FirstOrDefault();
                if (adminDetails == null)
                {
                    adminModel.LoginErrorMessage = "wrong credentials";
                    return View("LogIn", adminModel);
                }
                else
                {
                    Session["adminId"] = adminDetails.AdminId;
                    return RedirectToAction("Index", "QuotationController");
                }
            }
        }
    }
}
