using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieProject.Models
{
    public class Genre: Entity
    {
        public Genre()
        {
            this.MovieGenres = new HashSet<MovieGenre>();
        }
        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
    }
}