using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Translation.DAL;

namespace Translation.Models
{
    public class TextLineRepository
    {
        private static TextLineRepository instance;

        private TranslateContext db = new TranslateContext();

        public static TextLineRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new TextLineRepository();
                return instance;
            }
        }

        private List<TextLine> textline = null;

        /*private TextLineRepository()
        {
            this.textline = new List<TextLine>();
            TextLine textline1 = new TextLine
            { 
                ID = 1, 
                TimeStampBegin = new TimeSpan(0, 0, 0, 0, 1), 
                TimeStampEnd = new TimeSpan(0, 0, 0, 0, 3),
                OriginalText1 = "asdf",
                OriginalText2 = "",
                TranslationText1 = "asdf",
                TranslationText2 = "",
                SubtitleID = 1,
                LastModUserID = 1,
                LastModDate = DateTime.Now,
            };
            this.textline.Add(textline1);
        }*/

        public IEnumerable<TextLine> GetTextLines()
        {
            var result = from t in textline
                         orderby t.TimeStampBegin ascending
                         select t;
            return result;
        }

        public void AddTextLine(TextLine t)
        {
            int newID = 1;
            if (db.TextLines.Count() > 0)
            {
                newID = db.TextLines.Max(x => x.ID) + 1;
            }
            t.ID = newID;
            t.TimeStampBegin = new TimeSpan(0, 0, 0, 0, 1);
            t.TimeStampEnd = new TimeSpan(0, 0, 0, 0, 3);
            t.OriginalText1 = "asdf";
            t.OriginalText2 = "";
            t.TranslationText1 = "asdf";
            t.TranslationText2 = "";
            t.SubtitleID = 1;       // TODO GetSubtitleID
            t.LastModUserID = 1;    // TODO GetUser
            t.LastModDate = DateTime.Now;
            db.TextLines.Add(t);
            db.SaveChanges();
        }
    }
}