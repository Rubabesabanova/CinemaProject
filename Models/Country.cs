using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieProject.Models
{
    public class Country: Entity
    {
        public Country()
        {
            this.MovieCountries = new HashSet<MovieCountry>();
        }
        public virtual ICollection<MovieCountry> MovieCountries { get; set; }
    }
}