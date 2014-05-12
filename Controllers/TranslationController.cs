using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Translation.DAL;
using Translation.Models;

namespace Translation.Controllers
{
    public class TranslationController : Controller
    {
        private TranslateContext db = new TranslateContext();

        // GET /Translation/1
        public ActionResult Index(int id = 0)
        {
            if (id < 1)
            {
                return RedirectToAction("Index", "Home");
            }
            // Viewmodel, jeij
            //int id = 1;
            var model = new ViewModel();
            model.SubtitleItem = SubtitleRepository.Instance.GetSubtitle(id);
            model.CommentItems = CommentRepository.Instance.GetComments(id);

            return View(model);
        }

        // POST /Translation/1
        [HttpPost]
        public ActionResult Index(string Text, int id = 0)
        {
            if (id < 1)
            {
                return RedirectToAction("Index", "Home");
            }
            Comment c = new Comment();
            c.Text = Text;
            c.SubtitleID = id;
            c.AuthorID = System.Web.HttpContext.Current.User.Identity.Name;
            CommentRepository.Instance.AddComment(c);
            var model = new ViewModel();
            model.SubtitleItem = SubtitleRepository.Instance.GetSubtitle(id);
            model.CommentItems = CommentRepository.Instance.GetComments(id);

            return View(model);
        }

        // GET /Translation/Read/
        public ActionResult Read()
        {
            var text = TextLineRepository.Instance.GetTextLines();
            return View(text);
        }

        [HttpPost]
        public ActionResult New(FormCollection form)
        {
            Subtitle s = new Subtitle();
            s.Name = form["Name"];
            s.VideoDescription = form["VideoDescription"];
            s.Language = form["Language"];
            s.ForHardOfHearing = form["ForHardOfHearing"].Contains("true");
            s.CollaborationAllowed = form["CollaborationAllowed"].Contains("true");
            s.Contributor = System.Web.HttpContext.Current.User.Identity.Name;
            s.VideoType = form["VideoType"];
            s.VideoGenre = form["VideoGenre"];
            s.Picture = form["Picture"];
            s.File = form["File"];
            SubtitleRepository.Instance.AddSubtitle(s);
            if (s.File != null)
            {
                SubtitleRepository.Instance.ParseText(s.File, s.ID);
            }
            return RedirectToAction("Edit", "Translation");
        }
        public ActionResult New()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult EditFile()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Search(String query, String hear, String language, String type, String genre)
        {
            var model = new ViewModel();
            bool forhardofhearing = !String.IsNullOrEmpty(hear);
            model.SubtitleItems = SubtitleRepository.Instance.GetSubtitles(query, forhardofhearing, language);
            return View(model);
        }
    }
}