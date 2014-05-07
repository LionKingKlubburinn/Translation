using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Translation.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public String Username { get; set; }
        public String CommentText { get; set; }
        public DateTime CommentDate { get; set; }
    }
}