using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieProject.Models
{
    public class Hall : Entity
    {
        public Hall() {
            Seats = new List<Seat>();
        }
        public List<Seat> Seats { get; set; }
    }
}