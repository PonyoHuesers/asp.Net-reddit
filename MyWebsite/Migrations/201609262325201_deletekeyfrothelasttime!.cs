using System.Data.Entity.Migrations;

namespace MyWebsite.Migrations
{
    public partial class deletekeyfrothelasttime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Replies", "Key");
        }

        public override void Down()
        {
            AddColumn("dbo.Replies", "Key", c => c.Decimal(false, 18, 2));
        }
    }
}