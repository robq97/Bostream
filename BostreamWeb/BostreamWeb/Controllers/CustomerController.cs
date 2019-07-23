using BostreamWeb.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BostreamWeb.Controllers
{

    public class CustomerController : Controller
    {
        public ActionResult CustomerView()
        {
            // entity del web.config para instanciar la base de datos
            BostreamEntities1 db = new BostreamEntities1();

            //lista de los customers que se encuentren en la base de datos
            List<Customer> customerList = db.Customers.Include(x => x.Task).ToList();

            //instancia de viewmodel se utiliza para manejar entity de customer
            //de esta manera, en caso de que se hagan cambios en customers, no se afecta el view
            CustomerViewModel customerViewModel = new CustomerViewModel();

            List <CustomerViewModel> customerViewModelList = customerList.Select(x => new CustomerViewModel
            {
                CustomerID = x.CustomerID,
                CompanyName = x.CompanyName,
                Phone = x.Phone,
                Note = x.Note,
                TaskID = x.TaskID,
                //TaskTitle =  x.Task.Title,
                PersonID = x.PersonID,
                Quotations = x.Quotations
            }).ToList();

            return View(customerViewModelList);
        }

        //public ActionResult CustomerView()
        //{
        //    return View();
        //}

        public ActionResult NewCustomer()
        {
            return View();
        }

    }
}