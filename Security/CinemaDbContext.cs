using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MovieProject.Models;

namespace MovieProject.Security
{
    public class CinemaDbContext: DbContext
    {
        public CinemaDbContext() : base("cinema") { }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieCountry> MovieCountries { get; set; }
        public virtual DbSet<MovieGenre> MovieGenres { get; set; }
        public virtual DbSet<Hall> Halls { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Movie Country
            modelBuilder.Entity<MovieCountry>().HasKey(c => new { c.MovieId, c.CountryId });

            modelBuilder.Entity<Movie>()
                .HasMany(x => x.MovieCountries)
                .WithRequired()
                .HasForeignKey(c => c.MovieId);

            modelBuilder.Entity<Country>()
            .HasMany(x => x.MovieCountries)
            .WithRequired()
            .HasForeignKey(c => c.CountryId);
            #endregion

            #region Movie Genre
            modelBuilder.Entity<MovieGenre>().HasKey(c => new { c.MovieId, c.GenreId });

            modelBuilder.Entity<Movie>()
                .HasMany(x => x.MovieGenres)
                .WithRequired()
                .HasForeignKey(c => c.MovieId);

            modelBuilder.Entity<Genre>()
            .HasMany(x => x.MovieGenres)
            .WithRequired()
            .HasForeignKey(c => c.GenreId);
            #endregion

        }
    }
}