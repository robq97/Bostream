using BostreamWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Bostream.Models;

namespace Bostream.Controllers
{
    public class AdminController : Controller
    {

        /// <summary>
        /// Muestra vista de LogIn en caso de que el admin no haya iniciado sesion.
        /// </summary>
        /// <returns>Vista de login para admins.</returns>
        public ActionResult LogIn()
        {
            if (Session["username"] != null)
            {
                return RedirectToAction("NewCustomer", "Customer");
            }
            return View();
        }

        /// <summary>
        /// Revisa que el admin este con una sesion iniciada
        /// </summary>
        /// <returns>Devuelve el HomePage Publico</returns>
        public ActionResult LogOut()
        {
            if (Session["username"] != null)
            {
                Session["username"] = null;
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Denied()
        {
            return View();
        }

        /// <summary>
        /// Metodo para la autenticacion de administradores.
        /// Accese a la instancia de la base de datos y compara con la informacion ingresada.
        /// </summary>
        /// <param name="login">Donde se almancena temporalmente la info ingresada</param>
        /// <returns>Con credenciales correctos devuelve vista de nuevo cliente, sino se mantiene en la misma</returns>
        [HttpPost]
        public ActionResult Authentication(Admin login)
        {
            if (ModelState.IsValid)
            {
                BostreamEntities1 db = new BostreamEntities1();
                    List<Admin> adminList = db.Admins.ToList();

                var user = (from userlist in adminList
                            where userlist.username == login.username && userlist.password == login.password
                            select new
                            {
                                userlist.AdminId,
                                userlist.username
                            }).ToList();
                if (user.FirstOrDefault() != null)
                {
                    Session["UserName"] = user.FirstOrDefault().username;
                    Session["UserID"] = user.FirstOrDefault().AdminId;
                    return RedirectToAction("NewCustomer", "Customer");
                }
                else
                {
                    return RedirectToAction("LogIn", "Admin");
                }

            }
            return new EmptyResult();
        }
    }
}
