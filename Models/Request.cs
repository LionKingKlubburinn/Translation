using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Translation.Models
{
    public class Request
    {
        public int ID { get; set; }
        public int Upvote { get; set; }
        public bool ForHardOfHearing { get; set; }
        public String RequestBy { get; set; }
        public String Name { get; set; }
        public String Language { get; set; }
        public DateTime DateCreated { get; set; }
    }
}