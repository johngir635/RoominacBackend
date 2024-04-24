namespace RoominacBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createtablebookagain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Instantbooking = c.Boolean(nullable: false),
                        SelfCheckIn = c.Boolean(nullable: false),
                        FreeCancelation = c.Boolean(nullable: false),
                        PropertyItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PropertyDetails", t => t.PropertyItemId, cascadeDelete: true)
                .Index(t => t.PropertyItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "PropertyItemId", "dbo.PropertyDetails");
            DropIndex("dbo.Bookings", new[] { "PropertyItemId" });
            DropTable("dbo.Bookings");
        }
    }
}
