using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Translation.Models;

namespace Translation.Controllers
{
    public class TranslationController : Controller
    {
        // GET /Translation/1
        public ActionResult Index(int id = 1)
        {
            // Viewmodel, jeij
            //int id = 1;
            var model = new ViewModel();
            model.TranslationItems = TranslationRepository.Instance.GetTranslation(id);
            model.CommentItems = CommentRepository.Instance.GetComments(id);

            return View(model);
        }

        // POST /Translation/
        [HttpPost]
        public ActionResult Index(string Text, int id = 1)
        {
            Comment c = new Comment();
            c.Text = Text;
            c.TranslationID = id;
            CommentRepository.Instance.AddComment(c);
            var model = new ViewModel();
            model.TranslationItems = TranslationRepository.Instance.GetTranslation(id);
            model.CommentItems = CommentRepository.Instance.GetComments(id);

            return View(model);
        }

        // GET /Translation/Read/
        public ActionResult Read()
        {
            var text = TextLineRepository.Instance.GetTextLines();
            return View(text);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}

    }
}