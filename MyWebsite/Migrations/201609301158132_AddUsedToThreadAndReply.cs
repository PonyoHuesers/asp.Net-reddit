namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsedToThreadAndReply : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Replies", "Used", c => c.Int(nullable: false));
            AddColumn("dbo.Threads", "Used", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Threads", "Used");
            DropColumn("dbo.Replies", "Used");
        }
    }
}
