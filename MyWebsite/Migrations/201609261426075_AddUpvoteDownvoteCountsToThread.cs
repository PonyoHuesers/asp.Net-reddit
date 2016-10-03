using System.Data.Entity.Migrations;

namespace MyWebsite.Migrations
{
    public partial class AddUpvoteDownvoteCountsToThread : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Threads", "upvoteCount", c => c.Int(false));
            AddColumn("dbo.Threads", "downvoteCount", c => c.Int(false));
        }

        public override void Down()
        {
            DropColumn("dbo.Threads", "downvoteCount");
            DropColumn("dbo.Threads", "upvoteCount");
        }
    }
}