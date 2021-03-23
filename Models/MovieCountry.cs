using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieProject.Models
{
    public class MovieCountry
    {
        public int MovieId { get; set; }
        public int CountryId { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Country Country { get; set; }
    }
}