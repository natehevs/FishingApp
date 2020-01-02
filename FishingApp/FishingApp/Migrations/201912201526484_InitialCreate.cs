namespace FishingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enthusiasts",
                c => new
                    {
                        EnthusiastID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnthusiastID);
            
            CreateTable(
                "dbo.Gears",
                c => new
                    {
                        GearID = c.Int(nullable: false, identity: true),
                        MarkerID = c.Int(nullable: false),
                        Rod = c.String(),
                        Reel = c.String(),
                        Line = c.String(),
                    })
                .PrimaryKey(t => t.GearID);
            
            CreateTable(
                "dbo.LocationMarkers",
                c => new
                    {
                        MarkerID = c.Int(nullable: false, identity: true),
                        EnthusiastID = c.Int(nullable: false),
                        Species = c.String(),
                        DateTimeCaught = c.DateTime(nullable: false),
                        BaitUsed = c.String(),
                        GearID = c.Int(nullable: false),
                        LakeName = c.String(),
                        TechniqueID = c.Int(nullable: false),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        AverageRating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MarkerID)
                .ForeignKey("dbo.Enthusiasts", t => t.EnthusiastID, cascadeDelete: true)
                .ForeignKey("dbo.Gears", t => t.GearID, cascadeDelete: true)
                .ForeignKey("dbo.TechniqueModels", t => t.TechniqueID, cascadeDelete: true)
                .Index(t => t.EnthusiastID)
                .Index(t => t.GearID)
                .Index(t => t.TechniqueID);
            
            CreateTable(
                "dbo.TechniqueModels",
                c => new
                    {
                        TechniqueID = c.Int(nullable: false, identity: true),
                        Technique = c.String(),
                    })
                .PrimaryKey(t => t.TechniqueID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.LocationMarkers", "TechniqueID", "dbo.TechniqueModels");
            DropForeignKey("dbo.LocationMarkers", "GearID", "dbo.Gears");
            DropForeignKey("dbo.LocationMarkers", "EnthusiastID", "dbo.Enthusiasts");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.LocationMarkers", new[] { "TechniqueID" });
            DropIndex("dbo.LocationMarkers", new[] { "GearID" });
            DropIndex("dbo.LocationMarkers", new[] { "EnthusiastID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TechniqueModels");
            DropTable("dbo.LocationMarkers");
            DropTable("dbo.Gears");
            DropTable("dbo.Enthusiasts");
        }
    }
}
