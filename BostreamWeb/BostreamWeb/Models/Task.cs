using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bostream.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DeadLine { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int CustomerId { get; set; }
    }
}