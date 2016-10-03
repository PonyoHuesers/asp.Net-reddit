namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNullableReplyIdToREply : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Replies", "ReplyId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Replies", "ReplyId");
        }
    }
}
