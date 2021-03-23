using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieProject.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<Movie> Movies { get; set; }
        public List<Country> Countries { get; set; }
        public List<Genre> Genres { get; set; }
        public List<MovieGenre> MovieGenres { get; set; }
        public List<MovieCountry> MovieCountries { get; set; }
        public DateTime? start { get; set; }
        public DateTime? end { get; set; }
        public int? MovieId { get; set; }
    }
}