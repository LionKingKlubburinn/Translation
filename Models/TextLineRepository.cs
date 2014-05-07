using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Translation.Models
{
    public class TextLineRepository
    {
        private static TextLineRepository instance;

        public static TextLineRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new TextLineRepository();
                return instance;
            }
        }

        private List<TextLine> textl = null;

        private TextLineRepository()
        {
            this.textl = new List<TextLine>();
            //Comment commment1 = new Comment { ID = 1, Text = "Ég er að commenta!", CommentDate = new DateTime(2014, 3, 1, 12, 30, 00), Author = 1, TranslationID = 1 };
            //Comment commment2 = new Comment { ID = 2, Text = "Ég er að commenta!", CommentDate = new DateTime(2014, 3, 1, 12, 30, 00), Author = 2, TranslationID = 2 };
            //this.comments.Add(commment1);
            //this.comments.Add(commment2);
        }

        public IEnumerable<TextLine> GetTextLines()
        {
            var result = from t in textl
                         orderby t.TimeStampBegin ascending
                         select t;
            return result;
        }

        public void AddTextLine(TextLine t)
        {
            int newID = 1;
            if (textl.Count() > 0)
            {
                newID = textl.Max(x => x.ID) + 1;
            }
            t.ID = newID;
            t.TimeStampBegin = new TimeSpan(0, 0, 0, 1, 0);
            t.TimeStampEnd = new TimeSpan(0, 0, 0, 3, 0);
            t.OriginalText1 = "asdf";
            t.OriginalText2 = "";
            t.TranslationText1 = "asdf";
            t.TranslationText2 = "";
            t.TranslationID = 1;
            t.LastModUserID = 1;
            t.LastModDate = DateTime.Now;
            textl.Add(t);
        }
    }
}