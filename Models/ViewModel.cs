using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Translation.Models
{
    public class ViewModel
    {
        public IEnumerable<Subtitle> SubtitleItems { get; set; }
        public Subtitle SubtitleItem { get; set; }
        public IEnumerable<Comment> CommentItems { get; set; }
    }
}