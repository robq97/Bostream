using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BostreamWeb.Models
{
    public class ServiceViewModel
    {
        public int ServiceID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Quotation> Quotations { get; set; }

    }
}