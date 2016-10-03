using System.Data.Entity.Migrations;

namespace MyWebsite.Migrations
{
    public partial class AddCreatedDateToThread : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Threads", "Created", c => c.DateTime(false));
        }

        public override void Down()
        {
            DropColumn("dbo.Threads", "Created");
        }
    }
}