namespace Translation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Translations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DownloadCounter = c.Int(nullable: false),
                        ForHardOfHearing = c.Boolean(nullable: false),
                        Ready = c.Boolean(nullable: false),
                        CollaborationAllowed = c.Boolean(nullable: false),
                        Contributor = c.Int(nullable: false),
                        VideoType = c.String(),
                        VideoGenre = c.String(),
                        VideoDescription = c.String(),
                        Language = c.String(),
                        Picture = c.String(),
                        File = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Translations");
        }
    }
}
