using BostreamWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bostream.Controllers
{
    public class TaskController : Controller
    {

        //Devuelve el view de NewTask      
        public ActionResult NewTask()
        {
            return View();
        }

        /// <summary>
        /// Agrega una nueva tarea a un cliente determinado.
        /// </summary>
        /// <param name="_newTask"></param>
        /// <returns>actualizacion a la db con nueva tarea</returns>
        public ActionResult AddNewTask([Bind(Include = "Title, Deadline, Description, Priority, CustomerID")] Task _newTask)
        {
            if (ModelState.IsValid)
            {
                BostreamEntities1 db = new BostreamEntities1();
                db.Tasks.Add(_newTask);
                db.SaveChanges();
                return RedirectToAction("NewTask");
            }
            return View(_newTask);
        }

        [HttpPost]
        public ActionResult AddNewTask2(TaskViewModel model)
        {
            BostreamEntities1 db = new BostreamEntities1();
            List<Task> tasks = db.Tasks.ToList();

            Task tsk = new Task();

            try
            {
                tsk.Title = model.TaskTitle;
                DateTime date = DateTime.Parse(model.Deadline);
                tsk.Deadline = date;
                tsk.Priority = model.Priority;
                tsk.CustomerID = model.CustomerID;
                tsk.Description = model.Description;

                db.Tasks.Add(tsk);

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


            return View("NewTask", model);
        }
    }
}