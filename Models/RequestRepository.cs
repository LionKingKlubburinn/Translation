using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Translation.Models
{
    public class RequestRepository
    {
        private static RequestRepository instance;

        public static RequestRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new RequestRepository();
                return instance;
            }
        }

        private List<Request> requests = null;

        private RequestRepository()
        {
            this.requests = new List<Request>();
            Request request1 = new Request
            {
                DateCreated = DateTime.Now,
                ForHardOfHearing = false,
                ID = 1,
                Language = "Strump",
                Name = "Lion King",
                RequestBy = 1,
                Upvote = 0
            };
            this.requests.Add(request1);
            
        }

        public IEnumerable<Request> GetRequests()
        {
            var result = from r in requests
                         orderby r.DateCreated ascending
                         select r;
            return result;
        }

        public void AddRequest(Request r)
        {
            int newID = 1;
            if (requests.Count() > 0)
            {
                newID = requests.Max(x => x.ID) + 1;
            }
            r.DateCreated = DateTime.Now;
            r.ForHardOfHearing = false;
            r.ID = newID;
            r.Language = "Strump";
            r.Name = "Lion King";
            r.RequestBy = 1; //TODO GetUser
            r.Upvote = 0;

        }
    }
}