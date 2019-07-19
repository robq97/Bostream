using System;
using System.ComponentModel.DataAnnotations;

namespace Bostream.Models
{
    public class AdminViewModel
    {
        public int AdminId { get; set; }
        public int PersonId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
