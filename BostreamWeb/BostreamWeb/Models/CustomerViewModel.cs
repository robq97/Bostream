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
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Note { get; set; }
        public Task Task { get; set; }
        public Nullable<int> TaskID { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDesc { get; set; }
        public int? QuotationID { get; set; }
        public int? PersonID { get; set; }
        public Quotation Quotation { get; set; }
        public DateTime? QuotationCreationDate { get; set; }
        public DateTime? QuotationEndDate { get; set; }
        public string QuotationService { get; set; }
        public int? QuotationPrice { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}