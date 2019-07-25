namespace GoHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventionsForGosAndGenres : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Goes", "Artical_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Goes", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Goes", new[] { "Artical_Id" });
            DropIndex("dbo.Goes", new[] { "Genre_Id" });
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Goes", "Venue", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Goes", "Artical_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Goes", "Genre_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.Goes", "Artical_Id");
            CreateIndex("dbo.Goes", "Genre_Id");
            AddForeignKey("dbo.Goes", "Artical_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Goes", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Goes", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Goes", "Artical_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Goes", new[] { "Genre_Id" });
            DropIndex("dbo.Goes", new[] { "Artical_Id" });
            AlterColumn("dbo.Goes", "Genre_Id", c => c.Byte());
            AlterColumn("dbo.Goes", "Artical_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Goes", "Venue", c => c.String());
            AlterColumn("dbo.Genres", "Name", c => c.String());
            CreateIndex("dbo.Goes", "Genre_Id");
            CreateIndex("dbo.Goes", "Artical_Id");
            AddForeignKey("dbo.Goes", "Genre_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.Goes", "Artical_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
