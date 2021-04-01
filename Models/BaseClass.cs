using System.ComponentModel.DataAnnotations;

namespace OnePageApplication.Models
{
    public class BaseClass
    {
        [Key]
        public int Id { get; set; }

        [MinLength(5)]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}