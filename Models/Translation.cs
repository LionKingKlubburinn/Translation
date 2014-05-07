using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Translation.Models
{
    public class Translation
    {
        public int ID { get; set; }
        public int DownloadCounter { get; set; }
        public bool ForHardOfHearing { get; set; }
        public bool Ready { get; set; }
        public bool CollaborationAllowed { get; set; }
        public String Name { get; set; }
        public String Contributor { get; set; }
        public String VideoType { get; set; }
        public String VideoGenre { get; set; }
        public String VideoDescription { get; set; }
        public String Language { get; set; }
        public String Picture { get; set; }
        public String File { get; set; }
        public DateTime CommentDate { get; set; }
    }
}