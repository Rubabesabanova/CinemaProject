using System.ComponentModel.DataAnnotations.Schema;

namespace OnePageApplication.Models
{
    public class Project : BaseClass
    {
        public string Photo { get; set; }
        public string Description { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}