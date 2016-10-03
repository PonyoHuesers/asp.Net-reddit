using System.Data.Entity.Migrations;

namespace MyWebsite.Migrations
{
    public partial class AddCreatorToComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Creator", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Comments", "Creator");
        }
    }
}