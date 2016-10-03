namespace MyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCreatedToREply : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Replies", "Created", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Replies", "Created");
        }
    }
}
