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
            this.Movies = new HashSet<Movie>();
        }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}