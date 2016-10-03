namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedChildIdParentIdFromREply : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Replies", "CommentId");
            DropColumn("dbo.Replies", "Used");
            DropColumn("dbo.Replies", "ChildId");
            DropTable("dbo.Comments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ThreadId = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Creator = c.String(),
                        CommentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Replies", "ChildId", c => c.Int());
            AddColumn("dbo.Replies", "Used", c => c.Int(nullable: false));
            AddColumn("dbo.Replies", "CommentId", c => c.Int(nullable: false));
        }
    }
}
