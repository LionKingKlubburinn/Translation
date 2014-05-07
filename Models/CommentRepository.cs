using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Translation.Models
{
    public class CommentRepository
    {
        private static CommentRepository instance;

        public static CommentRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new CommentRepository();
                return instance;
            }
        }

        private List<Comment> comments = null;

        public IEnumerable<Comment> GetComments()
        {
            var result = from c in comments
                         orderby c.CommentDate ascending
                         select c;
            return result;
        }

        public void AddComment(Comment c)
        {
            int newID = 1;
            if (comments.Count() > 0)
            {
                newID = comments.Max(x => x.ID) + 1;
            }
            c.ID = newID;
            c.CommentDate = DateTime.Now;
            c.Author = 1;//TODO GetUserID
            c.Text = "veitekkihvaðégeraðgera";
            c.TranslationID = 1;//TODO GetTranslationID
            comments.Add(c);
        }
    }
}