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
        // GET /Translation
        public ActionResult Index()
        {
            // Viewmodel, jeij
            var model = new ViewModel();
            model.TranslationItems = TranslationRepository.Instance.GetTranslation(1);
            model.CommentItems = CommentRepository.Instance.GetComments();

            return View(model);
        }

        // POST /Translation/
        [HttpPost]
        public ActionResult Index(string Text)
        {
            Comment c = new Comment();
            c.Text = Text;
            CommentRepository.Instance.AddComment(c);
            var comments = CommentRepository.Instance.GetComments();
            return View(comments);
        }

        // GET /Translation/Read/
        public ActionResult Read()
        {
            var text = TextLineRepository.Instance.GetTextLines();
            return View(text);
        }
    }
}