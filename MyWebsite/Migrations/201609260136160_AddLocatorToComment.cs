using System.Data.Entity.Migrations;

namespace MyWebsite.Migrations
{
    public partial class AddLocatorToComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Locator", c => c.Int(false));
        }

        public override void Down()
        {
            DropColumn("dbo.Comments", "Locator");
        }
    }
}