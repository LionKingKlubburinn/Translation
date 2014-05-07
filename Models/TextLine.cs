using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Translation.Models
{
    public class TextLine
    {
        public int ID { get; set; }
        public String OriginalText1 { get; set; }
        public String OriginalText2 { get; set; }
        public String TranslationText1 { get; set; }
        public String TranslationText2 { get; set; }
        public String Translation { get; set; }
        public String LastModUser { get; set; }
        public DateTime LastModDate { get; set; }
    }
}