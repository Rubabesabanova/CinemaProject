namespace MovieProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingInitialTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieCountries",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieId, t.CountryId })
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PublicationDate = c.DateTime(nullable: false),
                        Duration = c.Double(nullable: false),
                        Link = c.String(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieGenres",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieId, t.GenreId })
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieGenres", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.MovieGenres", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.MovieCountries", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.MovieCountries", "CountryId", "dbo.Countries");
            DropIndex("dbo.MovieGenres", new[] { "GenreId" });
            DropIndex("dbo.MovieGenres", new[] { "MovieId" });
            DropIndex("dbo.MovieCountries", new[] { "CountryId" });
            DropIndex("dbo.MovieCountries", new[] { "MovieId" });
            DropTable("dbo.Genres");
            DropTable("dbo.MovieGenres");
            DropTable("dbo.Movies");
            DropTable("dbo.MovieCountries");
            DropTable("dbo.Countries");
        }
    }
}
