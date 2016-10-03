using System.Data.Entity.Migrations;

namespace MyWebsite.Migrations
{
    public partial class AddRatingToComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Rating", c => c.Int(false));
        }

        public override void Down()
        {
            DropColumn("dbo.Comments", "Rating");
        }
    }
}