using System.ComponentModel.DataAnnotations;

namespace OnePageApplication.Models
{
    public class About
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        [MinLength(5)]
        public string Title { get; set; }
        [MaxLength(30)]
        [MinLength(5)]
        public string PreTitle { get; set; }
        public string Text { get; set; }
        [MaxLength(255)]
        [MinLength(5)]
        public string Signature { get; set; }
    }
}