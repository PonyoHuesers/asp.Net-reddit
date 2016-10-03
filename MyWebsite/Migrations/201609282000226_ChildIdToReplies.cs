using System.Data.Entity.Migrations;

namespace MyWebsite.Migrations
{
    public partial class ChildIdToReplies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Replies", "ChildId", c => c.Int());
        }

        public override void Down()
        {
            DropColumn("dbo.Replies", "ChildId");
        }
    }
}