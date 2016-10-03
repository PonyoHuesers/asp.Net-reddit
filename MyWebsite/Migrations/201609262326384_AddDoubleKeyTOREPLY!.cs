using System.Data.Entity.Migrations;

namespace MyWebsite.Migrations
{
    public partial class AddDoubleKeyTOREPLY : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Replies", "Key", c => c.Double(false));
        }

        public override void Down()
        {
            DropColumn("dbo.Replies", "Key");
        }
    }
}