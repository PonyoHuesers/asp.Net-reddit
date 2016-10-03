namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTierToReply : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Replies", "Tier", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Replies", "Tier");
        }
    }
}
