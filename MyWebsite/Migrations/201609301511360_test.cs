using System.Data.Entity.Migrations;

namespace MyWebsite.Migrations
{
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Users");
        }

        public override void Down()
        {
            CreateTable(
                    "dbo.Users",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(),
                        ThreadId = c.Int(false),
                        Comment = c.String()
                    })
                .PrimaryKey(t => t.Id);
        }
    }
}