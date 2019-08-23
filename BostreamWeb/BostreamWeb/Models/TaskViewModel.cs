using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BostreamWeb.Models
{
    public class TaskViewModel
    {
        public int TaskId { get; set; }
        public string Task { get; set; }
        public string Deadline { get; set; }
        public string Description { get; set; }
        public byte Priority { get; set; }
        public int CustomerID { get; set; }

        // atributos adicionales

        public string TaskTitle { get; set; }

    }
}