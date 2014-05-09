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
            /*var users = new List<ApplicationUser>
            {
                new ApplicationUser {UserName="Einar", Email="einar", Id},
                new ApplicationUser {UserName="Einarthor", Email="einarthor"},
                new ApplicationUser {UserName="Einarthort", Email="einarthort"},
            };*/
            context.SaveChanges();

            var subtitles = new List<Subtitle>
            {
                new Subtitle { ID = 1, Name = "kinglion1", CollaborationAllowed=false, Contributor=1, DateCreated=DateTime.Now, DownloadCounter=0, File="neh", ForHardOfHearing=false, 
                    Language="islansk", Picture="neh", Ready=false, VideoDescription="desc", VideoGenre="flott", VideoType="allskonar"},
                new Subtitle { ID = 2, Name = "kinglion2", CollaborationAllowed=false, Contributor=1, DateCreated=DateTime.Now, DownloadCounter=0, File="neh", ForHardOfHearing=false, 
                    Language="islansk", Picture="neh", Ready=false, VideoDescription="desc", VideoGenre="flott", VideoType="allskonar" },
                new Subtitle { ID = 3, Name = "kinglion3", CollaborationAllowed=false, Contributor=1, DateCreated=DateTime.Now, DownloadCounter=0, File="neh", ForHardOfHearing=false, 
                    Language="islansk", Picture="neh", Ready=false, VideoDescription="desc", VideoGenre="flott", VideoType="allskonar" },
                new Subtitle { ID = 4, Name = "kinglion4", CollaborationAllowed=false, Contributor=1, DateCreated=DateTime.Now, DownloadCounter=0, File="neh", ForHardOfHearing=false, 
                    Language="islansk", Picture="neh", Ready=false, VideoDescription="desc", VideoGenre="flott", VideoType="allskonar" },
            };
            subtitles.ForEach(s => context.Subtitles.Add(s));
            context.SaveChanges();

            var comments = new List<Comment>
            {
                new Comment { ID=1, SubtitleID=1, Text="I love kinglion1", AuthorID=1, CommentDate=DateTime.Now},
                new Comment { ID=2, SubtitleID=2, Text="I love kinglion2", AuthorID=1, CommentDate=DateTime.Now},
                new Comment { ID=3, SubtitleID=3, Text="I love kinglion3", AuthorID=1, CommentDate=DateTime.Now},
                new Comment { ID=4, SubtitleID=4, Text="I love kinglion4", AuthorID=1, CommentDate=DateTime.Now}
            };
            comments.ForEach(c => context.Comments.Add(c));
            context.SaveChanges();
        }
    }
}