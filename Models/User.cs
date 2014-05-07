using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Translation.Models
{
    public class User
    {
        public int ID { get; set; }
        public bool Admin { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public String Nationality { get; set; }
        public String Picture { get; set; }
        public DateTime DateCreated { get; set; }

    }
}