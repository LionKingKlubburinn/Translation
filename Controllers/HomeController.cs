using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Translation.DAL;
using Translation.Helpers;
using Translation.Models;

namespace Translation.Controllers
{
    public class HomeController : BaseController 
    {
        private TranslateContext db = new TranslateContext();

        public ActionResult Index()
        {
            var model = RequestRepository.Instance.GetRequests();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(String query, String hear, String language, String type, String genre)
        {
            return RedirectToAction("Search", "Translation", new { 
                query = query, hear = hear, language = language, type = type, genre = genre });
        }

        public ActionResult SetCulture(string culture)
        {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);
            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");
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