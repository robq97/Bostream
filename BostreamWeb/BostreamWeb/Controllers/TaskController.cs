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
        public ActionResult AddNewTask([Bind(Include = "TaskId, Title, Deadline, Description, Priority, CustomerID")] Task _newTask)
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

            tsk.Title = model.TaskTitle;
            tsk.Deadline = model.Deadline;
            tsk.Priority = model.Priority;
            tsk.CustomerID = model.CustomerID;

            db.Tasks.Add(tsk);

            db.SaveChanges();


            return View(model);
        }
    }
}