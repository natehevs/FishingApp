namespace FishingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Latlongadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LocationMarkers", "Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.LocationMarkers", "Longitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LocationMarkers", "Longitude");
            DropColumn("dbo.LocationMarkers", "Latitude");
        }
    }
}
