using System.Data.Entity.Migrations;

namespace MyWebsite.Migrations
{
    public partial class AddNullableReplyIdToREply : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Replies", "ReplyId", c => c.Int());
        }

        public override void Down()
        {
            DropColumn("dbo.Replies", "ReplyId");
        }
    }
}