namespace FishingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class latlongstring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LocationMarkers", "Latitude", c => c.String());
            AlterColumn("dbo.LocationMarkers", "Longitude", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LocationMarkers", "Longitude", c => c.Double(nullable: false));
            AlterColumn("dbo.LocationMarkers", "Latitude", c => c.Double(nullable: false));
        }
    }
}
