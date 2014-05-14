using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Translation.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Email { get; set; }
        public string Nationality { get; set; }
        public string Image { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Admin { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("TranslateContext")
        {
        }
    }

}