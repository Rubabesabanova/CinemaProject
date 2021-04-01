using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnePageApplication.Models
{
    public class Package : BaseClass
    {
        public Package()
        {
            this.PackageElements = new HashSet<SkillElement>();
        }
        public decimal Price { get; set; }
        public virtual ICollection<SkillElement> PackageElements { get; set; }
    }
}