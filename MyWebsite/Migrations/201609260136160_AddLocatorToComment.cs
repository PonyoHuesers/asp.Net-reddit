namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocatorToComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Locator", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Locator");
        }
    }
}
