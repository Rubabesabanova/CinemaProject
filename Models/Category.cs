using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnePageApplication.Models
{
    public class Category : BaseClass
    {
        public Category()
        {
            Projects = new HashSet<Project>();
        }
        public int OrderBy { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}