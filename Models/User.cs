using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MovieProject.Models
{
    public class User: Entity
    {
        [Required(ErrorMessage = "The field is required")]
        [MinLength(2, ErrorMessage = "The minimum length of Surname is 2 characters")]
        public string Surname { get; set; }
        [DataType(DataType.EmailAddress)]
        [MaxLength(255)]
        [Remote("EmailIsUnique", "Auth", HttpMethod = "POST", ErrorMessage = "Email already exists.")]
        public string Email { get; set; }
        [MinLength(6)]
        [MaxLength(255)]
        public string Password { get; set; }

    }
}