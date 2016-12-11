namespace CynfoProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Users");
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        PlaceID = c.String(nullable: false, maxLength: 128),
                        PlaceName = c.String(nullable: false),
                        PlaceDescription = c.String(),
                        PlaceLogoURL = c.String(),
                        PlaceMajor = c.Int(nullable: false),
                        PlaceAddress = c.String(nullable: false),
                        Placecontact = c.String(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlaceID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Entity = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Places", "UserID", "dbo.Users");
            DropIndex("dbo.Places", new[] { "UserID" });
            DropTable("dbo.Users");
            DropTable("dbo.Places");
        }
    }
}
