using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Translation.Models
{
    public class Upvote
    {
        public int ID { get; set; }
        public int RequestId { get; set; }
        public String UserName { get; set; }
    }
}