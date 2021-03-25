using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace MovieProject.Models
{
    public class Hall: Entity
    {
        public Hall() {
            Seats = new List<Seat>();
        }
        public List<Seat> Seats { get; set; }
    }
}