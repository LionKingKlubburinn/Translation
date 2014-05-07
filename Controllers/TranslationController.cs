﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Translation.Models;

namespace Translation.Controllers
{
    public class TranslationController : Controller
    {
        public ActionResult Index()
        {
            var comments = CommentRepository.Instance.GetComments();
            return View(comments);
        }

    }
}