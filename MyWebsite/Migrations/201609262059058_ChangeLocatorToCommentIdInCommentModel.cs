namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLocatorToCommentIdInCommentModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CommentId", c => c.Int(nullable: false));
            DropColumn("dbo.Comments", "Locator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "Locator", c => c.Int(nullable: false));
            DropColumn("dbo.Comments", "CommentId");
        }
    }
}
