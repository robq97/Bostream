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
        /// Agrega nueva tarea a la db
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Vista de tareas</returns>
        [HttpPost]
        public ActionResult AddNewTask(TaskViewModel model)
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

        public ActionResult TaskList()

        {
            BostreamEntities1 db = new BostreamEntities1();
            List<Task> taskList = db.Tasks.ToList();
            TaskViewModel taskViewModel = new TaskViewModel();

            var list = (from t in db.Tasks
                        join c in db.Customers
                            on t.CustomerID equals c.CustomerID into ljt
                        from c in ljt.DefaultIfEmpty()
                        join p in db.People
                            on c.PersonID equals p.PersonId
                        select new TaskViewModel
                        {
                            Name = p.FirstName + " " + p.LastName,
                            TaskTitle = t.Title,
                            Deadline = t.Description,
                            Description = t.Description,
                            Priority = t.Priority
                        }).ToList();
            return View(list);
        }
    }
}