using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Translation.Models
{
    public class SubtitleRepository
    {
        private static SubtitleRepository instance;

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

        private SubtitleRepository()
        {
            this.subtitles = new List<Subtitle>();
            Subtitle translation1 = new Subtitle
            { 
                DateCreated = DateTime.Now,
                ForHardOfHearing = false,
                ID = 1,
                Language = "Strump", //TODO input
                Name = "Lion King", //TODO input
                DownloadCounter = 0,
                Ready = false,
                CollaborationAllowed = false,
                Contributor = 1, //TODO Getuser
                VideoType = "TODO", //TODO input
                VideoGenre = "TODO", //TODO input
                VideoDescription = "TODO", //TODO input
                Picture = "SL'OÐ 'A MYND!", //TODO input
                File = "/fæll/rts" //TODO input
            };
            Subtitle translation2 = new Subtitle
            {
                DateCreated = DateTime.Now,
                ForHardOfHearing = false,
                ID = 2,
                Language = "Strump", //TODO input
                Name = "Gisli's journey 2", //TODO input
                DownloadCounter = 0,
                Ready = false,
                CollaborationAllowed = false,
                Contributor = 1, //TODO Getuser
                VideoType = "TODO", //TODO input
                VideoGenre = "TODO", //TODO input
                VideoDescription = "TODO", //TODO input
                Picture = "SL'OÐ 'A MYND!", //TODO input
                File = "/fæll/rts" //TODO input
            };
            this.subtitles.Add(translation1);
            this.subtitles.Add(translation2);
        }

        public IEnumerable<Subtitle> GetTranslations(String Searchstring)
        {
            var result = from t in subtitles
                         orderby t.DateCreated ascending
                         select t;
            return result;
        }
        public IEnumerable<Subtitle> GetTranslation(int ID)
        {
            var result = from t in subtitles
                         where t.ID == ID
                         select t;
            return result;
        }

        public void AddTranslation(Subtitle r)
        {
            int newID = 1;
            if (subtitles.Count() > 0)
            {
                newID = subtitles.Max(x => x.ID) + 1;
            }
            r.DateCreated = DateTime.Now;
            r.ForHardOfHearing = false;
            r.ID = newID;
            r.Language = "Strump"; //TODO input
            r.Name = "Lion King"; //TODO input
            r.DownloadCounter = 0;
            r.Ready = false;
            r.CollaborationAllowed = false;
            r.Contributor = 1; //TODO Getuser
            r.VideoType = "TODO"; //TODO input
            r.VideoGenre = "TODO"; //TODO input
            r.VideoDescription = "TODO"; //TODO input
            r.Picture = "SL'OÐ 'A MYND!"; //TODO input
            r.File = "/fæll/rts"; //TODO input

        }
    }
}