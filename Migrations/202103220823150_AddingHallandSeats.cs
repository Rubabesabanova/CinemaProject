namespace MovieProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingHallandSeats : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Halls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HallId = c.Int(nullable: false),
                        Row = c.String(),
                        Column = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Halls", t => t.HallId, cascadeDelete: true)
                .Index(t => t.HallId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(nullable: false),
                        Email = c.String(maxLength: 255),
                        Password = c.String(maxLength: 255),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seats", "HallId", "dbo.Halls");
            DropIndex("dbo.Seats", new[] { "HallId" });
            DropTable("dbo.Users");
            DropTable("dbo.Seats");
            DropTable("dbo.Halls");
        }
    }
}
