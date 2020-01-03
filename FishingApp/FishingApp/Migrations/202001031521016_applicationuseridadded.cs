namespace FishingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applicationuseridadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enthusiasts", "ApplicationId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Enthusiasts", "ApplicationId");
            AddForeignKey("dbo.Enthusiasts", "ApplicationId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enthusiasts", "ApplicationId", "dbo.AspNetUsers");
            DropIndex("dbo.Enthusiasts", new[] { "ApplicationId" });
            DropColumn("dbo.Enthusiasts", "ApplicationId");
        }
    }
}
