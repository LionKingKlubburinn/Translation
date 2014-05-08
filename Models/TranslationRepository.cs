using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Translation.Models
{
    public class TranslationRepository
    {
        private static TranslationRepository instance;

        public static TranslationRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new TranslationRepository();
                return instance;
            }
        }

        private List<Translation> translations = null;

        private TranslationRepository()
        {
            this.translations = new List<Translation>();
            Translation translation1 = new Translation
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
            this.translations.Add(translation1);
            
        }

        public IEnumerable<Translation> GetTranslations(String Searchstring)
        {
            var result = from t in translations
                         orderby t.DateCreated ascending
                         select t;
            return result;
        }
        public IEnumerable<Translation> GetTranslation(int ID)
        {
            var result = from t in translations
                         where t.ID == ID
                         select t;
            return result.Take(1);
        }

        public void AddTranslation(Translation r)
        {
            int newID = 1;
            if (translations.Count() > 0)
            {
                newID = translations.Max(x => x.ID) + 1;
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