using System.Data.Entity.Migrations;

namespace MyWebsite.Migrations
{
    public partial class DeleteKeyFromReply : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Replies", "Key");
        }

        public override void Down()
        {
            AddColumn("dbo.Replies", "Key", c => c.Int(false));
        }
    }
}