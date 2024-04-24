namespace RoominacBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdifferentTabless : DbMigration
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
                .ForeignKey("dbo.PropertyItems", t => t.PropertyItemId, cascadeDelete: true)
                .Index(t => t.PropertyItemId);
            
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
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        SentAt = c.DateTime(nullable: false),
                        SenderId = c.Int(nullable: false),
                        RecipientId = c.Int(nullable: false),
                        SenderDeleted = c.Boolean(nullable: false),
                        SenderDeletedAt = c.DateTime(),
                        RecipientDeleted = c.Boolean(nullable: false),
                        RecipientDeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        SenderId = c.Int(nullable: false),
                        RecipientId = c.Int(nullable: false),
                        UserDeleted = c.Boolean(nullable: false),
                        UserDeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PropertyId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentDate = c.DateTime(nullable: false),
                        PaymentMethod = c.String(),
                        TransactionId = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PropertyItems", t => t.PropertyId, cascadeDelete: true)
                .ForeignKey("dbo.RoominacUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PropertyId);
            
            CreateTable(
                "dbo.RoominacUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(),
                        Email = c.String(),
                        Photo = c.String(),
                        Phone = c.String(),
                        GovId = c.String(),
                        Address = c.String(),
                        Address2 = c.String(),
                        Address3 = c.String(),
                        Emergencyphone = c.String(),
                        IdVerified = c.Boolean(nullable: false),
                        PhoneVerified = c.Boolean(nullable: false),
                        GovIdVerified = c.Boolean(nullable: false),
                        EmergencyContactProvided = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Method = c.String(nullable: false),
                        CardNumber = c.String(),
                        paymentType = c.Int(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        AcceptsRefunds = c.Boolean(nullable: false),
                        AcceptsCancellations = c.Boolean(nullable: false),
                        AcceptsModifications = c.Boolean(nullable: false),
                        RoominacUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RoominacUsers", t => t.RoominacUserId, cascadeDelete: true)
                .Index(t => t.RoominacUserId);
            
            CreateTable(
                "dbo.PersonalInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LegalName = c.String(),
                        EmailAddress = c.String(),
                        PhoneNumber = c.String(),
                        GovernmentID = c.String(),
                        Address = c.String(),
                        EmergencyContact = c.String(),
                        RoominacUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RoominacUsers", t => t.RoominacUserId, cascadeDelete: true)
                .Index(t => t.RoominacUserId);
            
            CreateTable(
                "dbo.PropertyDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoominacUserId = c.Int(nullable: false),
                        LocationName = c.String(),
                        Latitude = c.Single(nullable: false),
                        Longitude = c.Single(nullable: false),
                        Distance = c.Single(nullable: false),
                        NoOfBeds = c.Int(nullable: false),
                        Bathrooms = c.Int(nullable: false),
                        WiFi = c.Boolean(nullable: false),
                        TV = c.Boolean(nullable: false),
                        Kitchen = c.Boolean(nullable: false),
                        WashingMachine = c.Boolean(nullable: false),
                        FreeParking = c.Boolean(nullable: false),
                        PaidParking = c.Boolean(nullable: false),
                        AirConditioning = c.Boolean(nullable: false),
                        DedicatedSpaces = c.Boolean(nullable: false),
                        StepFreeEntrance = c.Boolean(nullable: false),
                        Widerthan32inch = c.Boolean(nullable: false),
                        StepFreePath = c.Boolean(nullable: false),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(nullable: false),
                        Price = c.Single(nullable: false),
                        Nights = c.Int(nullable: false),
                        PropertyType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RoominacUsers", t => t.RoominacUserId, cascadeDelete: true)
                .Index(t => t.RoominacUserId);
            
            CreateTable(
                "dbo.PropertyItemImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PropertyDetailId = c.Int(nullable: false),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PropertyDetails", t => t.PropertyDetailId, cascadeDelete: true)
                .Index(t => t.PropertyDetailId);
            
            CreateTable(
                "dbo.ReportedSuperHostProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReportedBy = c.String(),
                        Reason = c.String(),
                        ReportedAt = c.DateTime(nullable: false),
                        SuperHostId = c.Int(nullable: false),
                        RoominacUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RoominacUsers", t => t.RoominacUserId, cascadeDelete: true)
                .ForeignKey("dbo.SuperHosts", t => t.SuperHostId, cascadeDelete: true)
                .Index(t => t.SuperHostId)
                .Index(t => t.RoominacUserId);
            
            CreateTable(
                "dbo.SuperHosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsSuperHost = c.Boolean(nullable: false),
                        HostRating = c.Int(nullable: false),
                        TotalReviews = c.Int(nullable: false),
                        CurrentlyHosting = c.Boolean(nullable: false),
                        ProfileImage = c.Binary(),
                        Languages = c.String(),
                        Location = c.String(),
                        Job = c.String(),
                        Interests = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Education = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Identity = c.String(),
                        PropertyDetailId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PropertyDetails", t => t.PropertyDetailId)
                .Index(t => t.PropertyDetailId);
            
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
                .ForeignKey("dbo.PropertyItems", t => t.PropertyItemId, cascadeDelete: true)
                .ForeignKey("dbo.RoominacUsers", t => t.RoominacUserId, cascadeDelete: true)
                .Index(t => t.RoominacUserId)
                .Index(t => t.PropertyItemId);
            
            CreateTable(
                "dbo.TopTierStays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsSuperHost = c.Boolean(nullable: false),
                        PropertyDetailId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PropertyDetails", t => t.PropertyDetailId, cascadeDelete: true)
                .Index(t => t.PropertyDetailId);
            
            CreateTable(
                "dbo.WishlistItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PropertyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PropertyItems", t => t.PropertyId, cascadeDelete: true)
                .ForeignKey("dbo.RoominacUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PropertyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WishlistItems", "UserId", "dbo.RoominacUsers");
            DropForeignKey("dbo.WishlistItems", "PropertyId", "dbo.PropertyItems");
            DropForeignKey("dbo.TopTierStays", "PropertyDetailId", "dbo.PropertyDetails");
            DropForeignKey("dbo.Stays", "RoominacUserId", "dbo.RoominacUsers");
            DropForeignKey("dbo.Stays", "PropertyItemId", "dbo.PropertyItems");
            DropForeignKey("dbo.ReportedSuperHostProfiles", "SuperHostId", "dbo.SuperHosts");
            DropForeignKey("dbo.SuperHosts", "PropertyDetailId", "dbo.PropertyDetails");
            DropForeignKey("dbo.ReportedSuperHostProfiles", "RoominacUserId", "dbo.RoominacUsers");
            DropForeignKey("dbo.PropertyItemImages", "PropertyDetailId", "dbo.PropertyDetails");
            DropForeignKey("dbo.PropertyDetails", "RoominacUserId", "dbo.RoominacUsers");
            DropForeignKey("dbo.PersonalInformations", "RoominacUserId", "dbo.RoominacUsers");
            DropForeignKey("dbo.PaymentMethods", "RoominacUserId", "dbo.RoominacUsers");
            DropForeignKey("dbo.PaymentHistories", "UserId", "dbo.RoominacUsers");
            DropForeignKey("dbo.PaymentHistories", "PropertyId", "dbo.PropertyItems");
            DropForeignKey("dbo.Bookings", "PropertyItemId", "dbo.PropertyItems");
            DropIndex("dbo.WishlistItems", new[] { "PropertyId" });
            DropIndex("dbo.WishlistItems", new[] { "UserId" });
            DropIndex("dbo.TopTierStays", new[] { "PropertyDetailId" });
            DropIndex("dbo.Stays", new[] { "PropertyItemId" });
            DropIndex("dbo.Stays", new[] { "RoominacUserId" });
            DropIndex("dbo.SuperHosts", new[] { "PropertyDetailId" });
            DropIndex("dbo.ReportedSuperHostProfiles", new[] { "RoominacUserId" });
            DropIndex("dbo.ReportedSuperHostProfiles", new[] { "SuperHostId" });
            DropIndex("dbo.PropertyItemImages", new[] { "PropertyDetailId" });
            DropIndex("dbo.PropertyDetails", new[] { "RoominacUserId" });
            DropIndex("dbo.PersonalInformations", new[] { "RoominacUserId" });
            DropIndex("dbo.PaymentMethods", new[] { "RoominacUserId" });
            DropIndex("dbo.PaymentHistories", new[] { "PropertyId" });
            DropIndex("dbo.PaymentHistories", new[] { "UserId" });
            DropIndex("dbo.Bookings", new[] { "PropertyItemId" });
            DropTable("dbo.WishlistItems");
            DropTable("dbo.TopTierStays");
            DropTable("dbo.Stays");
            DropTable("dbo.SuperHosts");
            DropTable("dbo.ReportedSuperHostProfiles");
            DropTable("dbo.PropertyItemImages");
            DropTable("dbo.PropertyDetails");
            DropTable("dbo.PersonalInformations");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.RoominacUsers");
            DropTable("dbo.PaymentHistories");
            DropTable("dbo.Notifications");
            DropTable("dbo.Messages");
            DropTable("dbo.PropertyItems");
            DropTable("dbo.Bookings");
        }
    }
}
