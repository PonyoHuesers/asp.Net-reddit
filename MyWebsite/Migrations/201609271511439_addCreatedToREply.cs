using System.Data.Entity.Migrations;

namespace MyWebsite.Migrations
{
    public partial class addCreatedToREply : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Replies", "Created", c => c.DateTime(false));
        }

        public override void Down()
        {
            DropColumn("dbo.Replies", "Created");
        }
    }
}