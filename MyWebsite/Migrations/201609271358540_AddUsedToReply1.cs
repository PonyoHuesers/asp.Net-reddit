namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsedToReply1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Replies", "Used", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Replies", "Used");
        }
    }
}
