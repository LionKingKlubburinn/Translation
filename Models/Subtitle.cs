using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Translation.Models
{
    public class Subtitle
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public bool ForHardOfHearing { get; set; }
        public String Contributor { get; set; } // ID a user
        public String VideoType { get; set; }
        public String VideoGenre { get; set; }
        public String VideoDescription { get; set; }
        public String Language { get; set; }
        public String Picture { get; set; }
        public String File { get; set; }
        public DateTime DateCreated { get; set; }
    }
}