﻿using System;
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

            var requests = new List<Request>
            {
                new Request { ID=1, Name="InABundercup", DateCreated=DateTime.Now, ForHardOfHearing=false, Language="utlansk", RequestByID=1, Upvote=0},
                new Request { ID=2, Name="SwingersClub 9", DateCreated=DateTime.Now, ForHardOfHearing=false, Language="utlansk", RequestByID=1, Upvote=0},
                new Request { ID=3, Name="Palli gone wild 4", DateCreated=DateTime.Now, ForHardOfHearing=false, Language="utlansk", RequestByID=1, Upvote=0},
                new Request { ID=4, Name="Hipp og kúl félagið 2", DateCreated=DateTime.Now, ForHardOfHearing=false, Language="utlansk", RequestByID=1, Upvote=0},
            };
            requests.ForEach(r => context.Requests.Add(r));
            context.SaveChanges();

            var textLines = new List<TextLine>
            {
                new TextLine { ID=1, LastModDate=DateTime.Now, LastModUserID=1, OriginalText1="blabla", OriginalText2="bloblo", SubtitleID=1, TimeStampBegin=new TimeSpan(), 
                    TimeStampEnd=new TimeSpan(), TranslationText1="juttebro", TranslationText2="kikke po teve"},
                new TextLine { ID=2, LastModDate=DateTime.Now, LastModUserID=1, OriginalText1="blabla", OriginalText2="bloblo", SubtitleID=1, TimeStampBegin=new TimeSpan(), 
                    TimeStampEnd=new TimeSpan(), TranslationText1="juttebro", TranslationText2="kikke po teve"},
                new TextLine { ID=3, LastModDate=DateTime.Now, LastModUserID=1, OriginalText1="blabla", OriginalText2="bloblo", SubtitleID=1, TimeStampBegin=new TimeSpan(), 
                    TimeStampEnd=new TimeSpan(), TranslationText1="juttebro", TranslationText2="kikke po teve"},
                new TextLine { ID=4, LastModDate=DateTime.Now, LastModUserID=1, OriginalText1="blabla", OriginalText2="bloblo", SubtitleID=1, TimeStampBegin=new TimeSpan(), 
                    TimeStampEnd=new TimeSpan(), TranslationText1="juttebro", TranslationText2="kikke po teve"}
            };
            textLines.ForEach(t => context.TextLines.Add(t));
            context.SaveChanges();
        }
    }
}