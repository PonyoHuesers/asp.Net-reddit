using System.Data.Entity.Migrations;

namespace MyWebsite.Migrations
{
    public partial class RemovedChildIdParentIdFromREply : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Replies", "CommentId");
            DropColumn("dbo.Replies", "Used");
            DropColumn("dbo.Replies", "ChildId");
            DropTable("dbo.Comments");
        }

        public override void Down()
        {
            CreateTable(
                    "dbo.Comments",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(),
                        ThreadId = c.Int(false),
                        Rating = c.Int(false),
                        Creator = c.String(),
                        CommentId = c.Int(false)
                    })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Replies", "ChildId", c => c.Int());
            AddColumn("dbo.Replies", "Used", c => c.Int(false));
            AddColumn("dbo.Replies", "CommentId", c => c.Int(false));
        }
    }
}