namespace RoominacBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class houserulestable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HouseRules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PropertyId = c.Int(nullable: false),
                        Rule = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PropertyDetails", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HouseRules", "PropertyId", "dbo.PropertyDetails");
            DropIndex("dbo.HouseRules", new[] { "PropertyId" });
            DropTable("dbo.HouseRules");
        }
    }
}
