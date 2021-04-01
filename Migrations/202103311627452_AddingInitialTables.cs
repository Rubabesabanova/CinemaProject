namespace OnePageApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingInitialTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 20),
                        PreTitle = c.String(maxLength: 30),
                        Text = c.String(),
                        Signature = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderBy = c.Int(nullable: false),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Photo = c.String(),
                        Description = c.String(),
                        CategoryId = c.Int(nullable: false),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Facts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Icon = c.String(),
                        Point = c.Int(nullable: false),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Icon = c.String(),
                        Description = c.String(),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FeedBacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Holder = c.String(),
                        Position = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsVisible = c.Boolean(nullable: false),
                        OrderBy = c.Int(nullable: false),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PackageElements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderBy = c.Int(nullable: false),
                        PackageId = c.Int(nullable: false),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.PackageId, cascadeDelete: true)
                .Index(t => t.PackageId);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SkillElements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SkillId = c.Int(nullable: false),
                        Name = c.String(maxLength: 20),
                        Package_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Skills", t => t.SkillId, cascadeDelete: true)
                .ForeignKey("dbo.Packages", t => t.Package_Id)
                .Index(t => t.SkillId)
                .Index(t => t.Package_Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        SubDescription = c.String(),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Date = c.DateTime(),
                        Photo = c.String(),
                        Tag = c.String(),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceElements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Icon = c.String(),
                        Description = c.String(),
                        ServiceId = c.Int(nullable: false),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Logo = c.String(maxLength: 200),
                        Title = c.String(maxLength: 25),
                        PreTitle = c.String(maxLength: 60),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        SubFooterText = c.String(),
                        IntroPhoto = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceElements", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.PackageElements", "PackageId", "dbo.Packages");
            DropForeignKey("dbo.SkillElements", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.SkillElements", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.Projects", "CategoryId", "dbo.Categories");
            DropIndex("dbo.ServiceElements", new[] { "ServiceId" });
            DropIndex("dbo.SkillElements", new[] { "Package_Id" });
            DropIndex("dbo.SkillElements", new[] { "SkillId" });
            DropIndex("dbo.PackageElements", new[] { "PackageId" });
            DropIndex("dbo.Projects", new[] { "CategoryId" });
            DropTable("dbo.Settings");
            DropTable("dbo.Services");
            DropTable("dbo.ServiceElements");
            DropTable("dbo.Posts");
            DropTable("dbo.Skills");
            DropTable("dbo.SkillElements");
            DropTable("dbo.Packages");
            DropTable("dbo.PackageElements");
            DropTable("dbo.Menus");
            DropTable("dbo.FeedBacks");
            DropTable("dbo.Features");
            DropTable("dbo.Facts");
            DropTable("dbo.Projects");
            DropTable("dbo.Categories");
            DropTable("dbo.Abouts");
        }
    }
}
