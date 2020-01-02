namespace FishingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LocationMarkers", "Rating", c => c.Double(nullable: false));
            DropColumn("dbo.LocationMarkers", "AverageRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LocationMarkers", "AverageRating", c => c.Double(nullable: false));
            DropColumn("dbo.LocationMarkers", "Rating");
        }
    }
}
