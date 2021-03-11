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
            this.Genres = new HashSet<Genre>();
            this.Countries = new HashSet<Country>();
        }
        [Required(ErrorMessage = "The field is required")]
        public DateTime? PublicationDate { get; set; }
        [Required(ErrorMessage = "The field is required")]
        public double Duration { get; set; }
        [Required(ErrorMessage = "The field is required")]
        public string Link { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
    }
}