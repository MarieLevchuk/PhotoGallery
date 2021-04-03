namespace PhotoGallery.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        PhotoId = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Author = c.String(maxLength: 50),
                        Format = c.String(),
                    })
                .PrimaryKey(t => t.PhotoId);
            
            CreateTable(
                "dbo.PhotoGenre",
                c => new
                    {
                        Photo_PhotoId = c.Int(nullable: false),
                        Genre_GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Photo_PhotoId, t.Genre_GenreId })
                .ForeignKey("dbo.Photo", t => t.Photo_PhotoId, cascadeDelete: true)
                .ForeignKey("dbo.Genre", t => t.Genre_GenreId, cascadeDelete: true)
                .Index(t => t.Photo_PhotoId)
                .Index(t => t.Genre_GenreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhotoGenre", "Genre_GenreId", "dbo.Genre");
            DropForeignKey("dbo.PhotoGenre", "Photo_PhotoId", "dbo.Photo");
            DropIndex("dbo.PhotoGenre", new[] { "Genre_GenreId" });
            DropIndex("dbo.PhotoGenre", new[] { "Photo_PhotoId" });
            DropTable("dbo.PhotoGenre");
            DropTable("dbo.Photo");
            DropTable("dbo.Genre");
        }
    }
}
