using System.Data.Entity.Migrations;

namespace MyWebsite.Migrations
{
    public partial class AddUserThreadCommentModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Comments",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String()
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.Threads",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(),
                        Title = c.String()
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.Users",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String()
                    })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Threads");
            DropTable("dbo.Comments");
        }
    }
}