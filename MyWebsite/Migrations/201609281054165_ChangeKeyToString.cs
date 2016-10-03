using System.Data.Entity.Migrations;

namespace MyWebsite.Migrations
{
    public partial class ChangeKeyToString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Replies", "Key", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Replies", "Key");
        }
    }
}