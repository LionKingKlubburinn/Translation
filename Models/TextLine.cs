using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Translation.Models
{
    public class TextLine
    {
        public int ID { get; set; }
        public TimeSpan TimeStampBegin { get; set; } // Todo: annad?
        public TimeSpan TimeStampEnd { get; set; }
        public String OriginalText1 { get; set; }
        public String OriginalText2 { get; set; }
        public String TranslationText1 { get; set; }
        public String TranslationText2 { get; set; }
        public int TranslationID { get; set; }
        public int LastModUserID { get; set; }
        public DateTime LastModDate { get; set; }
    }
}