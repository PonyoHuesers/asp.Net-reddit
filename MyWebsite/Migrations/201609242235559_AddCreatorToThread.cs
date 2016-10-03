using System.Data.Entity.Migrations;

namespace MyWebsite.Migrations
{
    public partial class AddCreatorToThread : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Threads", "Creator", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Threads", "Creator");
        }
    }
}