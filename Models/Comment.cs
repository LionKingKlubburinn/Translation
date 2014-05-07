using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Translation.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public int TranslationID { get; set; }
        public int Author { get; set; } // Author ID
        public String Text { get; set; }
        public DateTime CommentDate { get; set; }
    }
}