using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Translation.Models
{
    public class Subtitle
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public int DownloadCounter { get; set; }
        public bool ForHardOfHearing { get; set; }
        public bool Ready { get; set; }
        public bool CollaborationAllowed { get; set; }
        public int Contributor { get; set; } // ID a user
        public String VideoType { get; set; }
        public String VideoGenre { get; set; }
        public String VideoDescription { get; set; }
        public String Language { get; set; }
        public String Picture { get; set; }
        public String File { get; set; }
        public DateTime DateCreated { get; set; }

        //public virtual ICollection<Comment> comments { get; set; }
        //public virtual ICollection<TextLine> textLines { get; set; }
    }
}