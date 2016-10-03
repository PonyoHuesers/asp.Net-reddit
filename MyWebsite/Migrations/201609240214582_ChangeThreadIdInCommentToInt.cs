namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeThreadIdInCommentToInt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "ThreadId_Id", "dbo.Threads");
            DropIndex("dbo.Comments", new[] { "ThreadId_Id" });
            AddColumn("dbo.Comments", "ThreadId", c => c.Int(nullable: false));
            DropColumn("dbo.Comments", "ThreadId_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "ThreadId_Id", c => c.Int());
            DropColumn("dbo.Comments", "ThreadId");
            CreateIndex("dbo.Comments", "ThreadId_Id");
            AddForeignKey("dbo.Comments", "ThreadId_Id", "dbo.Threads", "Id");
        }
    }
}
