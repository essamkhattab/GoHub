namespace GoHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateGoTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Goes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Venue = c.String(),
                        Artical_Id = c.String(maxLength: 128),
                        Genre_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Artical_Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .Index(t => t.Artical_Id)
                .Index(t => t.Genre_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Goes", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Goes", "Artical_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Goes", new[] { "Genre_Id" });
            DropIndex("dbo.Goes", new[] { "Artical_Id" });
            DropTable("dbo.Goes");
            DropTable("dbo.Genres");
        }
    }
}
