namespace FishingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationTechniqueAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LocationMarkers", "GearID", "dbo.Gears");
            DropIndex("dbo.LocationMarkers", new[] { "GearID" });
            AddColumn("dbo.LocationMarkers", "RodUsed", c => c.String());
            AddColumn("dbo.LocationMarkers", "ReelUsed", c => c.String());
            AddColumn("dbo.LocationMarkers", "LineUsed", c => c.String());
            DropColumn("dbo.LocationMarkers", "GearID");
            DropColumn("dbo.LocationMarkers", "Latitude");
            DropColumn("dbo.LocationMarkers", "Longitude");
            DropTable("dbo.Gears");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.LocationMarkers", "Longitude", c => c.String());
            AddColumn("dbo.LocationMarkers", "Latitude", c => c.String());
            AddColumn("dbo.LocationMarkers", "GearID", c => c.Int(nullable: false));
            DropColumn("dbo.LocationMarkers", "LineUsed");
            DropColumn("dbo.LocationMarkers", "ReelUsed");
            DropColumn("dbo.LocationMarkers", "RodUsed");
            CreateIndex("dbo.LocationMarkers", "GearID");
            AddForeignKey("dbo.LocationMarkers", "GearID", "dbo.Gears", "GearID", cascadeDelete: true);
        }
    }
}
