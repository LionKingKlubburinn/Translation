using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Translation.Models
{
    public class ViewModel
    {
        public List<Translation> TranslationItems { get; set; }
        public List<Comment> CommentItems { get; set; }
    }
}