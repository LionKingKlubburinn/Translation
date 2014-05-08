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

        private UserRepository()
        {
            this.users = new List<User>();
            User user1 = new User { Admin = false, UserName = "Einar", ID = 1, Nationality = "Island", Image = "nei", Email = "ja@ja.is", DateCreated = new DateTime(2014, 3, 1, 12, 30, 00) };
            this.users.Add(user1);
        }

        public void AddUser(String UserName, String Email, String Image, String Nationality)
        {
            User u = new User();
            int newID = 1;
            if (users.Count() > 0)
            {
                newID = users.Max(x => x.ID) + 1;
            }
            u.ID = newID;
            u.UserName = UserName;
            u.DateCreated = DateTime.Now;
            u.Admin = false;
            u.Email = Email;
            u.Image = Image;
            u.Nationality = Nationality;
            users.Add(u);
        }
    }
}