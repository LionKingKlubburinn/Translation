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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}