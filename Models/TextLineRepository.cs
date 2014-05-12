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

        public IEnumerable<TextLine> GetTextLines()
        {
            var result = from t in db.TextLines
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
            t.LastModDate = DateTime.Now;
            db.TextLines.Add(t);
            db.SaveChanges();
        }

        public void ChangeTextLine(TextLine t)
        {
            t.LastModDate = DateTime.Now;
            db.TextLines.Add(t);
            db.SaveChanges();
        }
    }
}