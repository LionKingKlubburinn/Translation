using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Translation.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public int SubtitleID { get; set; }
        public int AuthorID { get; set; }
        public String Text { get; set; }
        public DateTime CommentDate { get; set; }

    }
}