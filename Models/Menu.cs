using System.ComponentModel.DataAnnotations;

namespace OnePageApplication.Models
{
    public class Menu : BaseClass
    {
        public bool IsVisible { get; set; }
        public int OrderBy { get; set; }
    }
}