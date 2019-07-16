using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BostreamWeb.Controllers
{
    public class QuotationController : Controller
    {
        // GET: Quotation
        public ActionResult NewQuotation()
        {
            return View();
        }
    }
}