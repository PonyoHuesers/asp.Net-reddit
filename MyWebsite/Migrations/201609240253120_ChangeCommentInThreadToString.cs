namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCommentInThreadToString : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Threads", "Comment_Id", "dbo.Comments");
            DropIndex("dbo.Threads", new[] { "Comment_Id" });
            AddColumn("dbo.Threads", "Comment", c => c.String());
            DropColumn("dbo.Threads", "Comment_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Threads", "Comment_Id", c => c.Int());
            DropColumn("dbo.Threads", "Comment");
            CreateIndex("dbo.Threads", "Comment_Id");
            AddForeignKey("dbo.Threads", "Comment_Id", "dbo.Comments", "Id");
        }
    }
}
