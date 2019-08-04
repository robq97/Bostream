using BostreamWeb.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BostreamWeb.Controllers
{

    public class CustomerController : Controller
    {
        //public ActionResult CustomerView()
        //{
        //    // entity del web.config para instanciar la base de datos
        //    BostreamEntities1 db = new BostreamEntities1();

        //    //lista de los customers que se encuentren en la base de datos
        //    List<Customer> customerList = db.Customers.Include(x => x.Task).ToList();

        //    //instancia de viewmodel se utiliza para manejar entity de customer
        //    //de esta manera, en caso de que se hagan cambios en customers, no se afecta el view
        //    CustomerViewModel customerViewModel = new CustomerViewModel();

        //    List <CustomerViewModel> customerViewModelList = customerList.Select(x => new CustomerViewModel
        //    {
        //        CustomerID = x.CustomerID,
        //        CompanyName = x.CompanyName,
        //        Phone = x.Phone,
        //        Note = x.Note,
        //        TaskID = x.TaskID,
        //        //TaskTitle =  x.Task.Title,
        //        PersonID = x.PersonID,
        //        Quotations = x.Quotations
        //    }).ToList();

        //    return View(customerViewModelList);
        //}

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

        public ActionResult NewCustomer()
        {
            return View();
        }

    }
}