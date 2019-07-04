using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bostream.Models
{
    public class Newsletter
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool Subscribe { get; set; }
    }
}