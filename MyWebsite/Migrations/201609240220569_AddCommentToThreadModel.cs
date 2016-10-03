namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentToThreadModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Threads", "Comment_Id", c => c.Int());
            CreateIndex("dbo.Threads", "Comment_Id");
            AddForeignKey("dbo.Threads", "Comment_Id", "dbo.Comments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Threads", "Comment_Id", "dbo.Comments");
            DropIndex("dbo.Threads", new[] { "Comment_Id" });
            DropColumn("dbo.Threads", "Comment_Id");
        }
    }
}
