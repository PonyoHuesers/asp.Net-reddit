namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatedDateToThread : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Threads", "Created", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Threads", "Created");
        }
    }
}
