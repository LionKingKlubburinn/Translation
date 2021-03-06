﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Translation.Models;

namespace Translation.Controllers
{
    public class RequestController : Controller
    {
        // GET /Request/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        // POST /Request/
        [Authorize]
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            if (!String.IsNullOrEmpty(form["Name"]))
            {
                Request r = new Request();
                r.Name = form["Name"];
                r.Language = form["Language"];
                r.ForHardOfHearing = form["ForHardOfHearing"].Contains("true");
                r.RequestByID = System.Web.HttpContext.Current.User.Identity.Name;
                RequestRepository.Instance.AddRequest(r);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}