namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatorToThread : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Threads", "Creator", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Threads", "Creator");
        }
    }
}
