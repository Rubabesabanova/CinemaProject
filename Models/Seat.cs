using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieProject.Models
{
    public class Seat
    {
        [Key]
        public int Id { get; set; }
        public int HallId { get; set; }
        public virtual Hall Hall { get; set; }
        public string Row { get; set; }
        public int Column { get; set; }
    }
}