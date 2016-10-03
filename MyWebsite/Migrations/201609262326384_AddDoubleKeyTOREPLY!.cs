namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDoubleKeyTOREPLY : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Replies", "Key", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Replies", "Key");
        }
    }
}
