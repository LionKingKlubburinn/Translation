using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Translation.Models
{
    public class TextLine
    {
        public int ID { get; set; }
        public int RowID { get; set; }
        public String TimeStampBegin { get; set; } // Todo: annad?
        public String TimeStampEnd { get; set; }
        public String OriginalText1 { get; set; }
        public String OriginalText2 { get; set; }
        public String TranslationText1 { get; set; }
        public String TranslationText2 { get; set; }
        public int SubtitleID { get; set; }
        public String LastModUserID { get; set; }
        public DateTime LastModDate { get; set; }

    }
}