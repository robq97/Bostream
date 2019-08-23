//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BostreamWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Quotation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quotation()
        {
            this.Customers = new HashSet<Customer>();
        }
    
        public int QuotationID { get; set; }
        public int CustomerID { get; set; }
        public int ServiceID { get; set; }
        public System.DateTime CreationDate { get; set; }
        public System.DateTime ExpirationDate { get; set; }
        public Nullable<int> Price { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Service Service { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
