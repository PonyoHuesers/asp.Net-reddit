namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRAtingtoThread : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Threads", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Threads", "Rating");
        }
    }
}
