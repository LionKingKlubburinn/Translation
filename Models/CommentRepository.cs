﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Translation.DAL;
using Microsoft.AspNet.Identity;

namespace Translation.Models
{
    public class CommentRepository
    {
        private static CommentRepository instance;
        private TranslateContext db = new TranslateContext();

        public static CommentRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new CommentRepository();
                return instance;
            }
        }

        public IEnumerable<Comment> GetComments(int id)
        {
            var result = from c in db.Comments
                         where c.SubtitleID == id
                         orderby c.CommentDate ascending
                         select c;
            return result;
        }

        public void AddComment(Comment c)
        {
            int newID = 1;
            if (db.Comments.Count() > 0)
            {
                newID = db.Comments.Max(x => x.ID) + 1;
            }
            c.ID = newID;
            c.CommentDate = DateTime.Now;
            db.Comments.Add(c);
            db.SaveChanges();
        }
    }
}