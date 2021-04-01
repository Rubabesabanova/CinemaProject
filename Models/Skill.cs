using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnePageApplication.Models
{
    public class Skill : BaseClass
    {
        public Skill()
        {
            this.SkillElements = new HashSet<SkillElement>();
        }
        public string Description { get; set; }
        public string SubDescription { get; set; }
        public virtual ICollection<SkillElement> SkillElements { get; set; }
    }
}