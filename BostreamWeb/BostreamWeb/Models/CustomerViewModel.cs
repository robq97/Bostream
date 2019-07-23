using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BostreamWeb.Models
{
    public class CustomerViewModel
    {
        public int CustomerID { get; set; }
        public string CompanyName { get; set; }
        public int Phone { get; set; }
        public string Note { get; set; }
        public Task Task { get; set; }
        public Nullable<int> TaskID { get; set; }
        public string TaskTitle { get; set; }
        public int QuotationID { get; set; }
        public int PersonID { get; set; }
        public virtual ICollection<Quotation> Quotations { get; set; }

    }
}