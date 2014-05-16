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
        //Initializes the database with the following objects
        protected override void Seed(TranslateContext context)
        {
            var subtitles = new List<Subtitle>
            {
                new Subtitle { ID = 1, Name = "Lion King", Contributor="Palli", DateCreated=DateTime.Now, File=null, ForHardOfHearing=false, 
                    Language="is", Picture=null, VideoDescription="Íslenskur texti fyrir Lion King", VideoGenre="Teiknimynd", VideoType="Kvikmynd"},
                new Subtitle { ID = 2, Name = "Lion King 2", Contributor="Einar", DateCreated=DateTime.Now, File=null, ForHardOfHearing=true, 
                    Language="is", Picture=null, VideoDescription="Texti fyrir heyrnaskerta", VideoGenre="Teiknimynd", VideoType="Kvikmynd" },
                new Subtitle { ID = 3, Name = "Titanic", Contributor="Edda", DateCreated=DateTime.Now, File=null, ForHardOfHearing=false, 
                    Language="gb", Picture=null, VideoDescription="Enskur texti fyrir Titanic", VideoGenre="Drama", VideoType="Kvikmynd" },
                new Subtitle { ID = 4, Name = "E.T.", Contributor="Danni", DateCreated=DateTime.Now, File=null, ForHardOfHearing=false, 
                    Language="gb", Picture=null, VideoDescription="Enskur texti fyrir E.T.", VideoGenre="Ævintýri", VideoType="Kvikmynd" },
            };
            subtitles.ForEach(s => context.Subtitles.Add(s));
            context.SaveChanges();

            var comments = new List<Comment>
            {
                new Comment { ID=1, SubtitleID=1, Text="Frábær Þýðing hjá mér", AuthorID="Palli", CommentDate=DateTime.Now},
                new Comment { ID=2, SubtitleID=2, Text="Æði", AuthorID="Palli", CommentDate=DateTime.Now},
                new Comment { ID=3, SubtitleID=3, Text="Ég elska Titanic", AuthorID="Gísli", CommentDate=DateTime.Now},
                new Comment { ID=4, SubtitleID=4, Text="Where is he from, Uranus? Get it? Your anus?", AuthorID="Einar", CommentDate=DateTime.Now}
            };
            comments.ForEach(c => context.Comments.Add(c));
            context.SaveChanges();

            var requests = new List<Request>
            {
                new Request { ID=1, Name="Noah", DateCreated=DateTime.Now, ForHardOfHearing=false, Language="pl", RequestByID="4", Upvote=1},
                new Request { ID=2, Name="Spider Man 2", DateCreated=DateTime.Now, ForHardOfHearing=true, Language="is", RequestByID="3", Upvote=2},
                new Request { ID=3, Name="The Other Woman", DateCreated=DateTime.Now, ForHardOfHearing=false, Language="gb", RequestByID="2", Upvote=1},
                new Request { ID=4, Name="King Kong", DateCreated=DateTime.Now, ForHardOfHearing=true, Language="is", RequestByID="1", Upvote=1},
                new Request { ID=5, Name="Toy Story 3", DateCreated=DateTime.Now, ForHardOfHearing=false, Language="is", RequestByID="1", Upvote=5},
            };
            requests.ForEach(r => context.Requests.Add(r));
            context.SaveChanges();

            var textLines = new List<TextLine>
            {
                new TextLine { ID=1, RowID=1, LastModDate=DateTime.Now, LastModUserID="3", OriginalText1="Hakuna Matata", OriginalText2="What a wonderful phrase", SubtitleID=1, TimeStampBegin="00:00:00,103", 
                    TimeStampEnd="00:00:00,103", TranslationText1="Hakuna Matata", TranslationText2="Hversu dásamleg setning"},
                new TextLine { ID=2, RowID=1, LastModDate=DateTime.Now, LastModUserID="1", OriginalText1="blabla", OriginalText2="bloblo", SubtitleID=2, TimeStampBegin="00:00:00,103", 
                    TimeStampEnd="00:00:00,103", TranslationText1="juttebro", TranslationText2="kikke po teve"},
                new TextLine { ID=3, RowID=1, LastModDate=DateTime.Now, LastModUserID="4", OriginalText1="blabla", OriginalText2="bloblo", SubtitleID=3, TimeStampBegin="00:00:00,103", 
                    TimeStampEnd="00:00:00,103", TranslationText1="juttebro", TranslationText2="kikke po teve"},
                new TextLine { ID=4, RowID=1, LastModDate=DateTime.Now, LastModUserID="2", OriginalText1="blabla", OriginalText2="bloblo", SubtitleID=4, TimeStampBegin="00:00:00,103", 
                    TimeStampEnd="00:00:00,103", TranslationText1="juttebro", TranslationText2="kikke po teve"}
            };
            textLines.ForEach(t => context.TextLines.Add(t));
            context.SaveChanges();
        }
    }
}