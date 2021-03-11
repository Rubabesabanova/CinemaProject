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
        public DbSet<Country> Countries { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}