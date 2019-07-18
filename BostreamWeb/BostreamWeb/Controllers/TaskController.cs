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
        /// <summary>
        /// Muestra información de tarea asignada a un contacto.
        /// </summary>
        /// <returns>Vista de datos de una tarea.</returns>
        public ActionResult TaskList()
        {
            // entity del web.config para instanciar la base de datos
            BostreamEntities1 db = new BostreamEntities1();

            //lista de los customers que se encuentren en la base de datos
            List<Task> taskList = db.Tasks.ToList();

            //instancia de viewmodel se utiliza para manejar entity de customer
            //de esta manera, en caso de que se hagan cambios en customers, no se afecta el view
            TaskViewModel taskViewModel = new TaskViewModel();

            List<TaskViewModel> taskViewModelList = taskList.Select(x => new TaskViewModel
            {
                TaskId = x.TaskId,
                Title = x.Title,
                Deadline = x.Deadline,
                Description = x.Description,
                Priority = x.Priority,
                CustomerID = x.CustomerID
            }).ToList();
            return View(taskViewModelList);



        }
        public ActionResult NewTask()
        {
            return View();
        }
    }
}