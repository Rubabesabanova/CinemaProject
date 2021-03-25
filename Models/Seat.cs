using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace MovieProject.Models
{
    public class Seat
    {
        [Key]
        public int Id { get; set; }
        public int HallId { get; set; }
        public virtual Hall Hall { get; set; }
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Row should only contain letters.")]
        [Remote("SeatIsUnique", "Seats", HttpMethod = "POST", ErrorMessage = "That seat already exists.")]
        public string Row { get; set; }
        [Required(ErrorMessage = "The field is required")]
        public int Column { get; set; }
    }
}