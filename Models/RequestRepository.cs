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
            r.Upvote = 0;
            db.Requests.Add(r);
            db.SaveChanges();
        }

        public void AddUpvote(Upvote u)
        {
            if (HasUpvoted(u.UserName, u.RequestId) == 0)
            {
                return;
            }
            else
            {
                int newID = 1;
                if (db.Requests.Count() > 0)
                {
                    newID = db.Requests.Max(x => x.ID) + 1;
                }
                var request = (from x in db.Requests
                             where x.ID == u.RequestId
                             select x).First();
                request.Upvote = request.Upvote + 1;
                db.Upvotes.Add(u);
                db.SaveChanges();
            }
        }

        public int HasUpvoted(String user, int ID)
        {
            var result = (from u in db.Upvotes
                         where u.RequestId == ID && u.UserName == user
                         select u).FirstOrDefault();
            if(result == null)
            {
                return 1;
            }
            return 0;
        }
    }
}