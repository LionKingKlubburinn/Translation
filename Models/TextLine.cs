using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Translation.Models
{
    public class TextLine
    {
        public int ID { get; set; }
        public string OriginalText1 { get; set; }
        public string OriginalText2 { get; set; }
        public string FirstLine { get; set; }
        public string SecondLine { get; set; }
        public string Translation { get; set; }
        public string LastModUser { get; set; }
        public DateTime LastModDate { get; set; }
    }
}