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

        public IEnumerable<TextLine> GetTextLines(int id)
        {
            var result = from t in db.TextLines
                         where t.SubtitleID == id
                         orderby t.TimeStampBegin ascending
                         select t;
            return result;
        }

        public TextLine GetTextLine(int id, int line)
        {
            var result = (from t in db.TextLines
                         where t.SubtitleID == id
                         && t.RowID == line
                         select t).FirstOrDefault();
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
            t.LastModUserID = "Einar"; // TODO
            db.TextLines.Add(t);
            db.SaveChanges();
        }

        public void DeleteTextLines(int subid)
        {
            var toDelete = db.TextLines.Where(t => t.SubtitleID == subid).ToList();
            foreach (var t in toDelete)
            {
                db.TextLines.Remove(t);
            }
            db.SaveChanges();
        }

        public void ChangeTextLine(int id, int line, String newline1, String newline2)
        {
            var textline = (from t in db.TextLines
                          where t.SubtitleID == id
                          && t.RowID == line
                          select t).FirstOrDefault();

            textline.LastModDate = DateTime.Now;
            textline.TranslationText1 = newline1;
            textline.TranslationText2 = newline2;
            db.SaveChanges();
        }
    }
}