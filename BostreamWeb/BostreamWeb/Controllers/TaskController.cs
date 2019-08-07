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

        public ActionResult AddNewTask([Bind(Include = "TaskId, Title, Deadline, Description, Priority, CustomerID")] Task _newTask)
        {
            if (ModelState.IsValid)
            {
                BostreamEntities1 db = new BostreamEntities1();
                db.Task.Add(_newTask);
                db.SaveChanges();
                return RedirectToAction("NewTask");
            }
            return View(_newTask);
        }
    }
}