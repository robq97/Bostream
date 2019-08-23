using BostreamWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
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

        /// <summary>
        /// Agrega nueva tarea a la db
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Vista de tareas</returns>
        [HttpPost]
        public ActionResult AddNewQuotation(QuotationViewModel model)
        {
            BostreamEntities1 db = new BostreamEntities1();
            List<Quotation> tasks = db.Quotations.ToList();

            Quotation qt = new Quotation();

            try
            {

                qt.CreationDate = DateTime.Now;
                qt.CustomerID = model.CustomerID;
                qt.ExpirationDate = model.ExpirationDate;
                qt.Price = model.Price;
                qt.ServiceID = model.ServiceID;
                

                db.Quotations.Add(qt);

                db.SaveChanges();

            }

            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }


            return View("NewQuotation", model);
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

            var list = (from q in db.Quotations
                        join c in db.Customers
                            on q.CustomerID equals c.CustomerID
                        join p in db.People
                            on c.PersonID equals p.PersonId
                        join s in db.Services
                            on q.ServiceID equals s.ServiceID
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