namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteKeyFromReply : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Replies", "Key");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Replies", "Key", c => c.Int(nullable: false));
        }
    }
}