using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Translation.Controllers
{
    public class RequestController : Controller
    {
        [HttpPost]
        public ActionResult Index()
        {
            //Request r = new Request();
            //c.Text = Text;
            //CommentRepository.Instance.AddComment(c);
            ////int id = 1;
            //var model = new ViewModel();
            //model.TranslationItems = TranslationRepository.Instance.GetTranslation(id);
            //model.CommentItems = CommentRepository.Instance.GetComments();
            return View();
        }
    }
}