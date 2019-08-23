using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BostreamWeb.Models
{
    public class QuotationViewModel
    {
        public int QuotationID { get; set; }
        public int CustomerID { get; set; }
        public int ServiceID { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int? Price { get; set; }
        public string Name { get; set; }
        public string QuotationService { get; set; }

    }
}