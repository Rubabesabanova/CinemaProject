using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnePageApplication.Models
{
    public class SocialMedia
    {
        [Key]
        public int Id { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Behance { get; set; }
        public string Youtube { get; set; }
        public string Twitter { get; set; }
    }
}