using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Translation.DAL;
using Translation.Models;

namespace Translation.Controllers
{
    public class HomeController : Controller 
    {
        private TranslateContext db = new TranslateContext();

        // GET /
        public ActionResult Index()
        {
            var model = RequestRepository.Instance.GetRequests();
            return View(model);
        }

        // POST / (redirect á Translation/Search)
        [HttpPost]
        public ActionResult Index(String query, String hear, String language, String type, String genre)
        {
            return RedirectToAction("Search", "Translation", new { 
                query = query, hear = hear, language = language, type = type, genre = genre });
        }

        
        [Authorize]
        [HttpPost]
        public ActionResult UpVote(int RequestID)
        {
            Upvote u = new Upvote();
            u.RequestId = RequestID;
            u.UserName = System.Web.HttpContext.Current.User.Identity.Name;
            RequestRepository.Instance.AddUpvote(u);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult DeleteRequest(int id = 0)
        {
            if (id < 1)
            {
                return RedirectToAction("Index", "Home");
            }
            RequestRepository.Instance.DeleteRequest(id);
            return RedirectToAction("Index", "Home");
        }
    }
}