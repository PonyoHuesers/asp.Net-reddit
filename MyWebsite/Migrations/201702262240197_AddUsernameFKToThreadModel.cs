namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsernameFKToThreadModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "ThreadId", "dbo.Threads");
            DropForeignKey("dbo.Comments", "UsernameId", "dbo.Usernames");
            DropIndex("dbo.Comments", new[] { "ThreadId" });
            DropIndex("dbo.Comments", new[] { "UsernameId" });
            DropTable("dbo.Comments");
            DropTable("dbo.Threads");
            DropTable("dbo.Usernames");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Usernames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Threads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Rating = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        UpvoteCount = c.Int(nullable: false),
                        DownvoteCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ThreadId = c.Int(nullable: false),
                        UsernameId = c.Int(nullable: false),
                        Name = c.String(),
                        Rating = c.Int(nullable: false),
                        Tier = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Key = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Comments", "UsernameId");
            CreateIndex("dbo.Comments", "ThreadId");
            AddForeignKey("dbo.Comments", "UsernameId", "dbo.Usernames", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "ThreadId", "dbo.Threads", "Id", cascadeDelete: true);
        }
    }
}
