using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Translation.Models
{
    public class ViewModel
    {
        public IEnumerable<Translation> TranslationItems { get; set; }
        public IEnumerable<Comment> CommentItems { get; set; }
    }
}