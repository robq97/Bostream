﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bostream.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult ServiceList()
        {
            return View();
        }
    }
}