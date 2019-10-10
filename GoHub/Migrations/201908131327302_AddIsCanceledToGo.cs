namespace GoHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCanceledToGo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Goes", "IsCanceled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Goes", "IsCanceled");
        }
    }
}
