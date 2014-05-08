using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Translation.Models;

namespace Translation.Controllers
{
    public class RequestController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            Request r = new Request();
            r.Name = Convert.ToString(form["Name"]);
            r.Language = Convert.ToString(form["Language"]);
            r.ForHardOfHearing = Convert.ToBoolean(form["ForHardOfHearing"]);
            RequestRepository.Instance.AddRequest(r);
            return View("Index");
        }
    }
}