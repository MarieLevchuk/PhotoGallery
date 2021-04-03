namespace PhotoGallery.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEFModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photo", "Path", c => c.String(nullable: false));
            AlterColumn("dbo.Genre", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Photo", "Title", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Photo", "Title", c => c.String(maxLength: 50));
            AlterColumn("dbo.Genre", "Name", c => c.String(maxLength: 50));
            DropColumn("dbo.Photo", "Path");
        }
    }
}
