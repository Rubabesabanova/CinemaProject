using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieProject.Models
{
    public class Movie: Entity
    {
        public Movie()
        {
            this.MovieGenres = new HashSet<MovieGenre>();
            this.MovieCountries = new HashSet<MovieCountry>();
        }
        [Required(ErrorMessage = "The field is required")]
        public DateTime? PublicationDate { get; set; }
        [Required(ErrorMessage = "The field is required")]
        public double Duration { get; set; }
        [Required(ErrorMessage = "The field is required")]
        public string Link { get; set; }
        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
        public virtual ICollection<MovieCountry> MovieCountries { get; set; }
    }
}