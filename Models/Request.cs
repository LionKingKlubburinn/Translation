using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Translation.Models
{
    public class Request
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public int Upvote { get; set; }
        public bool ForHardOfHearing { get; set; }
        public int RequestByID { get; set; } // ID a user
        public String Language { get; set; }
        public DateTime DateCreated { get; set; }
    }

    //public class DefaultConnectiont : DbContext
    //{
      //  public DbSet<Request> Request { get; set; }
    //}
}