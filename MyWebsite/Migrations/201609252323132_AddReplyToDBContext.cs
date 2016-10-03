using System.Data.Entity.Migrations;

namespace MyWebsite.Migrations
{
    public partial class AddReplyToDBContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Replies",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(),
                        CommentId = c.Int(false),
                        ThreadId = c.Int(false),
                        Rating = c.Int(false),
                        Creator = c.String()
                    })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Replies");
        }
    }
}