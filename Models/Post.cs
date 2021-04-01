using System;
using System.ComponentModel.DataAnnotations;

namespace OnePageApplication.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? Date { get; set; }
        public string Photo { get; set; }
        public string Tag { get; set; }
        public string Text { get; set; }
    }
}