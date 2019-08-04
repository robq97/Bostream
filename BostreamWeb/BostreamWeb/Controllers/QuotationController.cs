using BostreamWeb.Models;
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

        public ActionResult QuotationList()
        {
            BostreamEntities1 db = new BostreamEntities1();
            List<Quotation> quotationList = db.Quotations.ToList();
            QuotationViewModel quotationViewModel = new QuotationViewModel();

            var list = (from c in db.Customers
                        join q in db.Quotations
                             on c.CustomerID equals q.CustomerID
                        join p in db.People
                             on c.PersonID equals p.PersonId
                        join s in db.Services
                             on q.ServiceID equals s.ServiceID into ljs
                        from s in ljs.DefaultIfEmpty()
                        select new QuotationViewModel
                        {
                            CustomerID = c.CustomerID,
                            Name = p.FirstName + " " + p.LastName,
                            QuotationService = s.Name,
                            CreationDate = q.CreationDate,
                            ExpirationDate = q.ExpirationDate,
                            Price = q.Price
                        }).ToList();
            return View(list);
        }
    }
}