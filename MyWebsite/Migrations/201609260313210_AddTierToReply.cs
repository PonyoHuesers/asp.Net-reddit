using System.Data.Entity.Migrations;

namespace MyWebsite.Migrations
{
    public partial class AddTierToReply : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Replies", "Tier", c => c.Int(false));
        }

        public override void Down()
        {
            DropColumn("dbo.Replies", "Tier");
        }
    }
}