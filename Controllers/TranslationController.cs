using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult New(FormCollection form, HttpPostedFileBase File)
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
            //s.File = form["File"];
            if (File.ContentLength > 0)
            {
                var fileName = Path.GetFileName(File.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                File.SaveAs(path);
            }
            SubtitleRepository.Instance.AddSubtitle(s);
            if (s.File != "")
            {
                SubtitleRepository.Instance.ParseText(s.File, db.Subtitles.Max(x => x.ID), s.Contributor);
                return RedirectToAction("EditFile", "Translation", new { id = db.Subtitles.Max(x => x.ID), linenum = 1 }); // WADDAFOUQ HARDCODE??
            }
            return RedirectToAction("Edit", "Translation", new { id = db.Subtitles.Max(x => x.ID) });
        }

        [HttpGet]
        public ActionResult New(String name, String language, String hear = "False")
        {
            // TODO: make language work
            Subtitle model = new Subtitle();
            model.Name = name;
            model.ForHardOfHearing = hear.Contains("True");
            model.Language = language;
            return View(model);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditFile(int id = 0, int linenum = 0)
        {
            if (id < 1 || linenum < 1)
            {
                return RedirectToAction("Index", "Home");
            }
            TextLine model = TextLineRepository.Instance.GetTextLine(id, linenum);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditFile(String Line1, String Line2, int id = 0, int linenum = 0)
        {
            if (id < 1 || linenum < 1)
            {
                return RedirectToAction("Index", "Home");
            }
            linenum++;
            return RedirectToAction("EditFile", "Translation", new { id = id, linenum = linenum });
        }

        [HttpGet]
        public ActionResult Search(String query, String hear, String language, String type, String genre)
        {
            var model = new ViewModel();
            bool forhardofhearing = !String.IsNullOrEmpty(hear);
            model.SubtitleItems = SubtitleRepository.Instance.GetSubtitles(query, forhardofhearing, language, type, genre);
            return View(model);
        }
    }
}