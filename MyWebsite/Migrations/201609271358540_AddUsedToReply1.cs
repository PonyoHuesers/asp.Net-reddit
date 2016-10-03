using System.Data.Entity.Migrations;

namespace MyWebsite.Migrations
{
    public partial class AddUsedToReply1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Replies", "Used", c => c.Int(false));
        }

        public override void Down()
        {
            DropColumn("dbo.Replies", "Used");
        }
    }
}