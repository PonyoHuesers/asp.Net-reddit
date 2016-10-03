namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUpvoteDownvoteCountsToThread : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Threads", "upvoteCount", c => c.Int(nullable: false));
            AddColumn("dbo.Threads", "downvoteCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Threads", "downvoteCount");
            DropColumn("dbo.Threads", "upvoteCount");
        }
    }
}
