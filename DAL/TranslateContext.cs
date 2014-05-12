using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Translation.Models;

namespace Translation.DAL
{
    public class TranslateContext : DbContext
    {
        public TranslateContext() : base("TranslateContext")
        {
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Subtitle> Subtitles { get; set; }
        public DbSet<TextLine> TextLines { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}