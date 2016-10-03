using System.Data.Entity.Migrations;

namespace MyWebsite.Migrations
{
    public partial class SeeyaKeyReplies : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Replies", "Key");
        }

        public override void Down()
        {
            AddColumn("dbo.Replies", "Key", c => c.Double(false));
        }
    }
}