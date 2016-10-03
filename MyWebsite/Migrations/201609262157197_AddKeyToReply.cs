using System.Data.Entity.Migrations;

namespace MyWebsite.Migrations
{
    public partial class AddKeyToReply : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Replies", "Key", c => c.Int(false));
            DropColumn("dbo.Replies", "ReplyId");
            DropColumn("dbo.Replies", "Used");
        }

        public override void Down()
        {
            AddColumn("dbo.Replies", "Used", c => c.Byte(false));
            AddColumn("dbo.Replies", "ReplyId", c => c.Int());
            DropColumn("dbo.Replies", "Key");
        }
    }
}