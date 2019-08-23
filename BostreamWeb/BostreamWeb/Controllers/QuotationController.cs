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
        /// <summary>
        /// Crea nueva cotizacion
        /// </summary>
        /// <returns>Cambios a la db de cotizaciones</returns>
        public ActionResult NewQuotation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddQuotation([Bind (Include = "QuotationID, CustomerID, ServiceID, CreationDate, ExpirationDate, Price")] Quotation _NewQuotation)
        {
            if (ModelState.IsValid)
            {
                BostreamEntities1 db = new BostreamEntities1();
                db.Quotations.Add(_NewQuotation);
                db.SaveChanges();
                return RedirectToAction("CustomerView");
            }
            return View(_NewQuotation);
        }

        [HttpPost]
        public ActionResult AddQuotation2(QuotationViewModel model)
        {
            BostreamEntities1 db = new BostreamEntities1();

            Quotation qt = new Quotation();

            qt.CustomerID = model.CustomerID;
            qt.CreationDate = model.CreationDate;
            qt.ExpirationDate = model.ExpirationDate;
            qt.Price = model.Price;
            qt.ServiceID = model.ServiceID;
           

            db.Quotations.Add(qt);

            db.SaveChanges();


            return View(model);
        }

        /// <summary>
        /// Obtiene informacion de diferentes tablas en relacion a la cotizaciones
        /// </summary>
        /// <returns>Lista de cotizaciones</returns>
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