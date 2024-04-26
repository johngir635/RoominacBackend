namespace RoominacBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatereviewclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "RatingDescription", c => c.String());
            AddColumn("dbo.Reviews", "Cleanliness", c => c.Int(nullable: false));
            AddColumn("dbo.Reviews", "Accuracy", c => c.Int(nullable: false));
            AddColumn("dbo.Reviews", "Location", c => c.Int(nullable: false));
            AddColumn("dbo.Reviews", "CheckIn", c => c.Int(nullable: false));
            AddColumn("dbo.Reviews", "Value", c => c.Int(nullable: false));
            AlterColumn("dbo.Reviews", "Rating", c => c.Double(nullable: false));
            CreateIndex("dbo.Reviews", "UserId");
            AddForeignKey("dbo.Reviews", "UserId", "dbo.RoominacUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "UserId", "dbo.RoominacUsers");
            DropIndex("dbo.Reviews", new[] { "UserId" });
            AlterColumn("dbo.Reviews", "Rating", c => c.Int(nullable: false));
            DropColumn("dbo.Reviews", "Value");
            DropColumn("dbo.Reviews", "CheckIn");
            DropColumn("dbo.Reviews", "Location");
            DropColumn("dbo.Reviews", "Accuracy");
            DropColumn("dbo.Reviews", "Cleanliness");
            DropColumn("dbo.Reviews", "RatingDescription");
        }
    }
}
