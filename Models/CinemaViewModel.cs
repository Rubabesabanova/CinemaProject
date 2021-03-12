using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieProject.Security;
using System.Data.Entity;

namespace MovieProject.Models
{
    public class CinemaViewModel
    {
        public List<Movie> Movies { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Country> Countries { get; set; }

        public List<Genre> GetGenresOfMovie(int id)
        {
            try
            {
                using (CinemaDbContext cinemaDbContext = new CinemaDbContext())
                {
                    return cinemaDbContext.Genres.Include(c => c.Movies).ToList();
                };
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return new List<Genre>();
        }
        public List<Country> GetCountriesOfMovie(int id)
        {
            try
            {
                using (CinemaDbContext cinemaDbContext = new CinemaDbContext())
                {
                    return cinemaDbContext.Countries.Include(c => c.Movies).ToList();
                };
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return new List<Country>();
        }
    }
}