using System.Data.Entity.Migrations;

namespace MyWebsite.Migrations
{
    public partial class AddUsedToReply : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Replies", "Used", c => c.Byte(false));
        }

        public override void Down()
        {
            DropColumn("dbo.Replies", "Used");
        }
    }
}