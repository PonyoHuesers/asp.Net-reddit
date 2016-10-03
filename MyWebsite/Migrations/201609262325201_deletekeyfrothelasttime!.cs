namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletekeyfrothelasttime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Replies", "Key");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Replies", "Key", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
