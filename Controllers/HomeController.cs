using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Translation.Models;

namespace Translation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var requests = RequestRepository.Instance.GetRequests();
            return View(requests);
        }

        [HttpPost]
        public ActionResult Index(String query, String type)
        {
            return RedirectToAction("Search", "Translation", new { query = query, type = type });
        }
    }
}