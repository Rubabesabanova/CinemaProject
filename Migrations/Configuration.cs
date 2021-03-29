namespace MovieProject.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MovieProject.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieProject.Security.CinemaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MovieProject.Security.CinemaDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
                context.Countries.AddOrUpdate(
                 p => p.Name,
                  new Country { Name = "Italy" },
                 new Country { Name = "France" },
                  new Country { Name = "Canada" }
                );
            context.Halls.AddOrUpdate(
                 p => p.Name,
                  new Hall { Name = "Artcraft" },
                 new Hall { Name = "Astor" },
                  new Hall { Name = "Bleecker Street" }
                );
            context.Genres.AddOrUpdate(
                 p => p.Name,
                  new Genre { Name = "Horror" },
                 new Genre { Name = "Art" },
                  new Genre { Name = "Drama" }
                );
        }
    }
}
