using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Translation.DAL;

namespace Translation.Models
{
    public class SubtitleRepository
    {
        private static SubtitleRepository instance;

        private TranslateContext db = new TranslateContext();

        public static SubtitleRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new SubtitleRepository();
                return instance;
            }
        }

        public IEnumerable<Subtitle> GetSubtitles(String Searchstring)
        {
            var result = from s in db.Subtitles
                         where s.Name.Contains(Searchstring)
                         orderby s.DateCreated ascending
                         select s;
            return result;
        }
        public Subtitle GetSubtitle(int ID)
        {
            var result = (from s in db.Subtitles
                         where s.ID == ID
                         select s).FirstOrDefault();
            return result;
        }

        public void AddSubtitle(Subtitle s)
        {
            int newID = 1;
            if (db.Subtitles.Count() > 0)
            {
                newID = db.Subtitles.Max(x => x.ID) + 1;
            }
            s.DateCreated = DateTime.Now;
            //s.ForHardOfHearing = false;
            s.ID = newID;
            //s.Language = "Strump"; //TODO input
            //s.Name = "Lion King"; //TODO input
            s.DownloadCounter = 0;
            s.Ready = false;
            s.Contributor = "sgsf"; //TODO Getuser
            //s.VideoType = "TODO"; //TODO input
            //s.VideoGenre = "TODO"; //TODO input
            //s.VideoDescription = "TODO"; //TODO input
            //s.Picture = "SL'OÐ 'A MYND!"; //TODO input
            //s.File = "/fæll/rts"; //TODO input
            //subtitles.Add(s);
            db.Subtitles.Add(s);
            db.SaveChanges();
        }
    }
}