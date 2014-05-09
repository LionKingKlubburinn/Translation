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

        private CommentRepository()
        {
            this.comments = new List<Comment>();
            Comment commment1 = new Comment { ID = 1, Text = "Ég er að commenta!", CommentDate = new DateTime(2014, 3, 1, 12, 30, 00), AuthorID = 1, SubtitleID = 1 };
            Comment commment2 = new Comment { ID = 2, Text = "Ég er að commenta!", CommentDate = new DateTime(2014, 3, 1, 12, 30, 00), AuthorID = 2, SubtitleID = 2 };
            this.comments.Add(commment1);
            this.comments.Add(commment2);
        }

        public IEnumerable<Comment> GetComments(int id)
        {
            var result = from c in comments
                         where c.SubtitleID == id
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
            c.AuthorID = 1;//TODO GetUserID
            // c.Text = comment;
            //c.TranslationID = 1;//TODO GetTranslationID
            comments.Add(c);
        }
    }
}