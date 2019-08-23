using BostreamWeb.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BostreamWeb.Controllers
{

    public class CustomerController : Controller
    {
        /// <summary>
        /// Metodo para la obtencion de datos de clintes de diferentes tablas.
        /// </summary>
        /// <returns>lista con infromacion de cada cliente</returns>
        public ActionResult CustomerView()
        {
            BostreamEntities1 db = new BostreamEntities1();
            List<Customer> customerList = db.Customers.ToList();
            CustomerViewModel customerViewModel = new CustomerViewModel();

            var list = (from c in db.Customers
                        join t in db.Tasks
                            on c.CustomerID equals t.CustomerID into ljt
                        from t in ljt.DefaultIfEmpty()
                        join p in db.People
                            on c.PersonID equals p.PersonId
                        join q in db.Quotations
                            on c.CustomerID equals q.CustomerID into ljq
                        from q in ljq.DefaultIfEmpty()
                        join s in db.Services
                            on q.ServiceID equals s.ServiceID into ljs
                        from s in ljs.DefaultIfEmpty()
                        select new CustomerViewModel
                        {
                            CustomerID = c.CustomerID,
                            Name = p.FirstName + " " + p.LastName,
                            Email = p.Email,
                            CompanyName = c.CompanyName,
                            Phone = c.Phone,
                            Note = c.Note,
                            TaskID = t.TaskId,
                            TaskTitle = t.Title,
                            TaskDesc = t.Description,
                            PersonID = c.PersonID,
                            QuotationService = s.Name,
                            QuotationCreationDate = q.CreationDate,
                            QuotationEndDate = q.ExpirationDate,
                            QuotationPrice = q.Price
                         }).ToList();
            return View(list);
        }

        /// <summary>
        /// redirecciona al view de agregar nuevo cliente
        /// </summary>
        /// <returns>view de NewCustomer</returns>
        public ActionResult NewCustomer()
        {
            return View();
        }

        /// <summary>
        /// ingresa info de cliente nuevo
        /// </summary>
        /// <param name="_newCustomer"></param>
        /// <returns></returns>
        public ActionResult AddNewCustomer([Bind (Include = "CustomerID, CompanyName, Phone," +
            "Note, TaskID, PersonID, QuotationID")] Customer _newCustomer)
        {
            if (ModelState.IsValid)
            {
                BostreamEntities1 db = new BostreamEntities1();
                db.Customers.Add(_newCustomer);
                db.SaveChanges();
                return RedirectToAction("CustomerView");
            }
            return View(_newCustomer);
        }
    }
}