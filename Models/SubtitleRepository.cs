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

        private List<Subtitle> subtitles = null;

        //private SubtitleRepository()
        //{
        //    this.subtitles = new List<Subtitle>();
        //    Subtitle translation1 = new Subtitle
        //    { 
        //        DateCreated = DateTime.Now,
        //        ForHardOfHearing = false,
        //        ID = 1,
        //        Language = "Strump", //TODO input
        //        Name = "Lion King", //TODO input
        //        DownloadCounter = 0,
        //        Ready = false,
        //        CollaborationAllowed = false,
        //        Contributor = 1, //TODO Getuser
        //        VideoType = "TODO", //TODO input
        //        VideoGenre = "TODO", //TODO input
        //        VideoDescription = "TODO", //TODO input
        //        Picture = "SL'OÐ 'A MYND!", //TODO input
        //        File = "/fæll/rts" //TODO input
        //    };
        //    Subtitle translation2 = new Subtitle
        //    {
        //        DateCreated = DateTime.Now,
        //        ForHardOfHearing = false,
        //        ID = 2,
        //        Language = "Strump", //TODO input
        //        Name = "Gisli's journey 2", //TODO input
        //        DownloadCounter = 0,
        //        Ready = false,
        //        CollaborationAllowed = false,
        //        Contributor = 1, //TODO Getuser
        //        VideoType = "TODO", //TODO input
        //        VideoGenre = "TODO", //TODO input
        //        VideoDescription = "TODO", //TODO input
        //        Picture = "SL'OÐ 'A MYND!", //TODO input
        //        File = "/fæll/rts" //TODO input
        //    };
        //    this.subtitles.Add(translation1);
        //    this.subtitles.Add(translation2);
        //}


        public IEnumerable<Subtitle> GetSubtitles(String Searchstring)
        {
            var result = from s in subtitles
                         where s.Name.Contains(Searchstring)
                         orderby s.DateCreated ascending
                         select s;
            return result;
        }
        public Subtitle GetSubtitle(int ID)
        {
            var result = (from s in subtitles
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
            s.ForHardOfHearing = false;
            s.ID = newID;
            s.Language = "Strump"; //TODO input
            //s.Name = "Lion King"; //TODO input
            s.DownloadCounter = 0;
            s.Ready = false;
            s.CollaborationAllowed = false;
            //s.Contributor = 1; //TODO Getuser
            //s.VideoType = "TODO"; //TODO input
            //s.VideoGenre = "TODO"; //TODO input
            //s.VideoDescription = "TODO"; //TODO input
            //s.Picture = "SL'OÐ 'A MYND!"; //TODO input
            s.File = "/fæll/rts"; //TODO input
            //subtitles.Add(s);
            db.Subtitles.Add(s);
            db.SaveChanges();
        }
    }
}