using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BostreamWeb.Models
{
    public class PersonViewModel
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}