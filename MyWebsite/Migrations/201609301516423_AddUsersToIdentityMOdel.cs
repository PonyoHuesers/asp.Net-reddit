using System.Data.Entity.Migrations;

namespace MyWebsite.Migrations
{
    public partial class AddUsersToIdentityMOdel : DbMigration
    {
        public override void Up()
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

        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}