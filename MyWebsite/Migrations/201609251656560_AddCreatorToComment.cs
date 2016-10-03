namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatorToComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Creator", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Creator");
        }
    }
}
