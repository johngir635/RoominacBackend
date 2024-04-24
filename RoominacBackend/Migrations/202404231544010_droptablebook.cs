namespace RoominacBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class droptablebook : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "PropertyItemId", "dbo.PropertyItems");
            DropIndex("dbo.Bookings", new[] { "PropertyItemId" });
            DropTable("dbo.Bookings");
            DropTable("dbo.PropertyItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PropertyItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Len = c.Int(nullable: false),
                        Type = c.Short(nullable: false),
                        Value = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Bookings", "PropertyItemId");
            AddForeignKey("dbo.Bookings", "PropertyItemId", "dbo.PropertyItems", "Id", cascadeDelete: true);
        }
    }
}
