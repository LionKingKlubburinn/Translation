using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Translation.DAL;
using Translation.Models;

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

        public IEnumerable<Subtitle> GetSubtitles(String Searchstring, bool forhardofhearing, String language, String type, String genre)
        {
            var result = from s in db.Subtitles
                         where s.Name.Contains(Searchstring)
                         && s.ForHardOfHearing == forhardofhearing
                         && (language == "any" || s.Language == language)
                         && (type == "any" || s.VideoType == type)
                         && (genre == "any" || s.VideoGenre == genre)
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
            s.ID = newID;
            s.DownloadCounter = 0;
            s.Ready = false;
            db.Subtitles.Add(s);
            db.SaveChanges();
        }

        public void ParseText(String filename, int TranslateID, String User)
        {
            StreamReader reader = File.OpenText(filename);//TEST TODO
            int count = 1;
            bool TextLine2Used = false;
            string line, lineID = "0", TimeStamp1 = "", TimeStamp2 = "", TextLine1 = "", TextLine2 = "";
            while ((line = reader.ReadLine()) != null)
            {
                if(line == "")
                {
                    if (!TextLine2Used)
                    {
                        TextLine2 = "";
                    }
                        TextLine t = new TextLine
                    {
                        LastModUserID = User,
                        OriginalText1 = TextLine1,
                        OriginalText2 = TextLine2,
                        SubtitleID = TranslateID,
                        TimeStampBegin = TimeStamp1,
                        TimeStampEnd = TimeStamp2,
                        TranslationText1 = "",
                        TranslationText2 = "",
                        RowID = Convert.ToInt32(lineID)
                    };
                    TextLineRepository.Instance.AddTextLine(t);
                    count = 1;
                    TextLine2Used = false;
                }
                else if(count == 1)
                {
                    lineID = line;
                    count++;
                }
                else if (count == 2)
                {
                    string[] part = line.Split(' ');
                    TimeStamp1 = part[0];
                    TimeStamp2 = part[2];
                    count++;
                }
                else if (count == 3)
                {
                    TextLine1 = line;
                    count++;
                }
                else if (count == 4)
                {
                    TextLine2 = line;
                    TextLine2Used = true;
                    count++;
                }
            }
            if(count != 1)
            {
                TextLine t = new TextLine
                {
                    LastModUserID = User,
                    OriginalText1 = TextLine1,
                    OriginalText2 = TextLine2,
                    SubtitleID = TranslateID,
                    TimeStampBegin = TimeStamp1,
                    TimeStampEnd = TimeStamp2,
                    TranslationText1 = "",
                    TranslationText2 = "",
                    RowID = Convert.ToInt32(lineID)
                };
                TextLineRepository.Instance.AddTextLine(t);
            }
        }

        public void ExportSubtitle(int TranslateID)
        {
            var result = from t in db.TextLines
                         where t.SubtitleID == TranslateID
                         orderby t.RowID ascending
                         select t;

            String SubtitleExport = "";
            foreach(var item in result)
            {
                if (item.TranslationText2 != null)
                {
                    SubtitleExport = SubtitleExport + item.RowID + Environment.NewLine + item.TimeStampBegin + " --> " +
                        item.TimeStampEnd + Environment.NewLine + item.TranslationText1 + Environment.NewLine + item.TranslationText2 + Environment.NewLine + Environment.NewLine;
                }
                else
                {
                    SubtitleExport = SubtitleExport + item.RowID + Environment.NewLine + item.TimeStampBegin + " --> " +
                        item.TimeStampEnd + Environment.NewLine + item.TranslationText1 + Environment.NewLine + Environment.NewLine;
                }
                
            }
            System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\test.txt"); //TODO
            file.WriteLine(SubtitleExport);

            file.Close();
        }
    }
}