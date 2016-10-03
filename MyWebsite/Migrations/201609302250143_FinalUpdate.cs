namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalUpdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "ThreadId");
            DropColumn("dbo.Users", "Comment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Comment", c => c.String());
            AddColumn("dbo.Users", "ThreadId", c => c.Int(nullable: false));
        }
    }
}
