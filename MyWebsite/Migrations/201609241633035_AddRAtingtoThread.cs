using System.Data.Entity.Migrations;

namespace MyWebsite.Migrations
{
    public partial class AddRAtingtoThread : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Threads", "Rating", c => c.Int(false));
        }

        public override void Down()
        {
            DropColumn("dbo.Threads", "Rating");
        }
    }
}