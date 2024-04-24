namespace RoominacBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createtablestaysagain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        When = c.DateTime(nullable: false),
                        NoOfGuset = c.Int(nullable: false),
                        RoominacUserId = c.Int(nullable: false),
                        ExactDaysPlusMinus = c.Int(nullable: false),
                        PropertyItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PropertyDetails", t => t.PropertyItemId, cascadeDelete: true)
                .Index(t => t.PropertyItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stays", "PropertyItemId", "dbo.PropertyDetails");
            DropIndex("dbo.Stays", new[] { "PropertyItemId" });
            DropTable("dbo.Stays");
        }
    }
}
