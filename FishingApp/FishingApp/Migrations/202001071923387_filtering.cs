namespace FishingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class filtering : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LocationMarkers", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LocationMarkers", "Rating", c => c.Double(nullable: false));
        }
    }
}
