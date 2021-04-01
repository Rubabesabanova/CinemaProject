using System.ComponentModel.DataAnnotations;

namespace OnePageApplication.Models
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        [MinLength(3)]
        public string Logo { get; set; }
        [MaxLength(25)]
        [MinLength(3)]
        public string Title { get; set; }
        [MaxLength(60)]
        [MinLength(3)]
        public string PreTitle { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string SubFooterText { get; set; }
        public string IntroPhoto { get; set; }
    }
}