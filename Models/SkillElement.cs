using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnePageApplication.Models
{
    public class SkillElement : BaseClass
    {
        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
    }
}