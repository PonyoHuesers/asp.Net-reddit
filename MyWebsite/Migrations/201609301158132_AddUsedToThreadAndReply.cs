using System.Data.Entity.Migrations;

namespace MyWebsite.Migrations
{
    public partial class AddUsedToThreadAndReply : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Replies", "Used", c => c.Int(false));
            AddColumn("dbo.Threads", "Used", c => c.Int(false));
        }

        public override void Down()
        {
            DropColumn("dbo.Threads", "Used");
            DropColumn("dbo.Replies", "Used");
        }
    }
}