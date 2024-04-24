namespace RoominacBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetopropertydeatilrating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PropertyDetails", "Rating", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PropertyDetails", "Rating");
        }
    }
}
