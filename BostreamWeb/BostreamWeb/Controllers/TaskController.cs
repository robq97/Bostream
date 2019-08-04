using BostreamWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bostream.Controllers
{
    public class TaskController : Controller
    {
        
      
        public ActionResult NewTask()
        {
            return View();
        }
    }
}