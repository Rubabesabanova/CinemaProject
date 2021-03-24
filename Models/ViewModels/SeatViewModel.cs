using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieProject.Models.ViewModels
{
    public class SeatViewModel
    {
        public List<Seat> Seats { get; set; }
        public List<Seat> SeatSingle { get; set; }
        public Seat Seat { get; set; }
        public List<Hall> Halls { get; set; }
        public int? SeatId { get; set; }
    }
}