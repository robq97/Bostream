using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bostream.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public DateTime LimitDate { get; set; }
        public string Desc { get; set; }
        public int ImporLev { get; set; }
       
    }
}