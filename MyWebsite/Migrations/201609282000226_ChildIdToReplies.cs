namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChildIdToReplies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Replies", "ChildId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Replies", "ChildId");
        }
    }
}
