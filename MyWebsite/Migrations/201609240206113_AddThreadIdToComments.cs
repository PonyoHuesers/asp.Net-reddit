namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddThreadIdToComments : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Threads", "Comment_Id", "dbo.Comments");
            DropForeignKey("dbo.Threads", "CommentId_Id", "dbo.Comments");
            DropIndex("dbo.Threads", new[] { "Comment_Id" });
            DropIndex("dbo.Threads", new[] { "CommentId_Id" });
            AddColumn("dbo.Comments", "ThreadId_Id", c => c.Int());
            CreateIndex("dbo.Comments", "ThreadId_Id");
            AddForeignKey("dbo.Comments", "ThreadId_Id", "dbo.Threads", "Id");
            DropColumn("dbo.Threads", "Name");
            DropColumn("dbo.Threads", "Comment_Id");
            DropColumn("dbo.Threads", "CommentId_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Threads", "CommentId_Id", c => c.Int());
            AddColumn("dbo.Threads", "Comment_Id", c => c.Int());
            AddColumn("dbo.Threads", "Name", c => c.String());
            DropForeignKey("dbo.Comments", "ThreadId_Id", "dbo.Threads");
            DropIndex("dbo.Comments", new[] { "ThreadId_Id" });
            DropColumn("dbo.Comments", "ThreadId_Id");
            CreateIndex("dbo.Threads", "CommentId_Id");
            CreateIndex("dbo.Threads", "Comment_Id");
            AddForeignKey("dbo.Threads", "CommentId_Id", "dbo.Comments", "Id");
            AddForeignKey("dbo.Threads", "Comment_Id", "dbo.Comments", "Id");
        }
    }
}
