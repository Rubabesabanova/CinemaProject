using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieProject.Models
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "The field is required")]
        [MinLength(2, ErrorMessage = "The minimum length of Name is 2 characters")]
        public string Name { get; set; }
    }
}