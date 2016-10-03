using System.Data.Entity.Migrations;

namespace MyWebsite.Migrations
{
    public partial class AddCommentToThread : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Threads", "Comment_Id", c => c.Int());
            AddColumn("dbo.Threads", "CommentId_Id", c => c.Int());
            CreateIndex("dbo.Threads", "Comment_Id");
            CreateIndex("dbo.Threads", "CommentId_Id");
            AddForeignKey("dbo.Threads", "Comment_Id", "dbo.Comments", "Id");
            AddForeignKey("dbo.Threads", "CommentId_Id", "dbo.Comments", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Threads", "CommentId_Id", "dbo.Comments");
            DropForeignKey("dbo.Threads", "Comment_Id", "dbo.Comments");
            DropIndex("dbo.Threads", new[] {"CommentId_Id"});
            DropIndex("dbo.Threads", new[] {"Comment_Id"});
            DropColumn("dbo.Threads", "CommentId_Id");
            DropColumn("dbo.Threads", "Comment_Id");
        }
    }
}