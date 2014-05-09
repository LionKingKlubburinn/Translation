using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Translation.Models;

namespace Translation.DAL
{
    public class TranslateInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<TranslateContext>
    {
        protected override void Seed(TranslateContext context)
        {
            var subtitles = new List<Subtitle>
            {
                new Subtitle { ID = 1, Name = "kinglion1" },
                new Subtitle { ID = 2, Name = "kinglion2" },
                new Subtitle { ID = 3, Name = "kinglion3" },
                new Subtitle { ID = 4, Name = "kinglion4" },
            };
            context.SaveChanges();

            var comments = new List<Comment>
            {
                new Comment { ID=1, SubtitleID=1, Text="I love kinglion1"},
                new Comment { ID=2, SubtitleID=2, Text="I love kinglion2"},
                new Comment { ID=3, SubtitleID=3, Text="I love kinglion3"},
                new Comment { ID=4, SubtitleID=4, Text="I love kinglion4"}
            };
            context.SaveChanges();
        }
    }
}