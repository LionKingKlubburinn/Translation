using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Translation.Models
{
    public class UserRepository
    {
        private static UserRepository instance;

        public static UserRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserRepository();
                return instance;
            }
        }

        private List<User> users = null;

        public void AddUser(User u, String username, String email, String image, String nationality)
        {
            int newID = 1;
            if (users.Count() > 0)
            {
                newID = users.Max(x => x.ID) + 1;
            }
            u.ID = newID;
            u.UserName = username;
            u.DateCreated = DateTime.Now;
            u.Admin = false;
            u.Email = email;
            u.Image = image;
            u.Nationality = nationality;
            users.Add(u);
        }
    }
}