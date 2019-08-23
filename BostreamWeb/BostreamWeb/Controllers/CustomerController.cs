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
                        join p in db.People
                            on c.PersonID equals p.PersonId
                        //join t in db.Tasks
                        //    on c.CustomerID equals t.CustomerID into ljt
                        //from t in ljt.DefaultIfEmpty()
                        select new CustomerViewModel
                        {
                            CustomerID = c.CustomerID,
                            Name = p.FirstName + " " + p.LastName,
                            Email = p.Email,
                            CompanyName = c.CompanyName,
                            Phone = c.Phone,
                            Note = c.Note,
                            ////TaskID = t.TaskId,
                            ////TaskTitle = t.Title,
                            ////TaskDesc = t.Description,
                            PersonID = c.PersonID,
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
        /// Crea una persona, seguido de un cliente
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Nueva vista de NewCustomer</returns>
        [HttpPost]
        public ActionResult AddCustomer(CustomerViewModel model)
        {
            var person = new Person
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };

            var customer = new Customer
            {
                CompanyName = model.CompanyName,
                Phone = model.Phone,
                Note = model.Note,
                PersonID = person.PersonId
            };

            using (var context = new BostreamEntities1())
            {
                context.People.Add(person);
                context.Customers.Add(customer);
                context.SaveChanges();
            }
            return View("NewCustomer", model);
        }

    }
}