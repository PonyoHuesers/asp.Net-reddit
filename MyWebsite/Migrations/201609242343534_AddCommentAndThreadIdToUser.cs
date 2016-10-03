using System.Data.Entity.Migrations;

namespace MyWebsite.Migrations
{
    public partial class AddCommentAndThreadIdToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ThreadId", c => c.Int(false));
            AddColumn("dbo.Users", "Comment", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Users", "Comment");
            DropColumn("dbo.Users", "ThreadId");
        }
    }
}