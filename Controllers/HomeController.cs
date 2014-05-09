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

        public ActionResult Index()
        {
            var requests = RequestRepository.Instance.GetRequests();
            return View(db.Requests.ToList());
        }

        [HttpPost]
        public ActionResult Index(String query, String type)
        {
            return RedirectToAction("Search", "Translation", new { query = query, type = type });
        }
    }
}