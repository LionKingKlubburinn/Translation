using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Translation.Models
{
    public class User : IdentityUser
    {
        public virtual UserInfo MyUserInfo { get; set; }
    }

    public class UserInfo
    {
        public int Id { get; set; }
        public bool Admin { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Nationality { get; set; }
        public string Image { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class MyDbContext : IdentityDbContext<User>
    {
        public MyDbContext()
            : base("DefaultConnection")
        {
        }
        public System.Data.Entity.DbSet<MyUserInfo> UserInfo { get; set; }
    }
}