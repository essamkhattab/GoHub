namespace GoHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyPropertiesToGo : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Goes", name: "Artical_Id", newName: "ArticalId");
            RenameColumn(table: "dbo.Goes", name: "Genre_Id", newName: "GenreId");
            RenameIndex(table: "dbo.Goes", name: "IX_Artical_Id", newName: "IX_ArticalId");
            RenameIndex(table: "dbo.Goes", name: "IX_Genre_Id", newName: "IX_GenreId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Goes", name: "IX_GenreId", newName: "IX_Genre_Id");
            RenameIndex(table: "dbo.Goes", name: "IX_ArticalId", newName: "IX_Artical_Id");
            RenameColumn(table: "dbo.Goes", name: "GenreId", newName: "Genre_Id");
            RenameColumn(table: "dbo.Goes", name: "ArticalId", newName: "Artical_Id");
        }
    }
}
