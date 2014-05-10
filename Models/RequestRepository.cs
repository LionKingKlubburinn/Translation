using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Translation.DAL;

namespace Translation.Models
{
    public class RequestRepository
    {
        private static RequestRepository instance;

        private TranslateContext db = new TranslateContext();

        public static RequestRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new RequestRepository();
                return instance;
            }
        }

        public IEnumerable<Request> GetRequests()
        {
            var result = from r in db.Requests
                         orderby r.DateCreated ascending
                         select r;
            return result;
        }

        public void AddRequest(Request r)
        {
            int newID = 1;
            if (db.Requests.Count() > 0)
            {
                newID = db.Requests.Max(x => x.ID) + 1;
            }
            r.DateCreated = DateTime.Now;
            r.ID = newID;
            r.RequestByID = "sgsf"; //TODO GetUser
            r.Upvote = 0;
            db.Requests.Add(r);
            db.SaveChanges();
        }
    }
}