using BostreamWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bostream.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string PhoneNum { get; set; }
        public string Notes { get; set; }
        public virtual Task Task { get; set; }
    }
}