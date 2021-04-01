using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnePageApplication.Models
{
    public class PackageElement: BaseClass
    {
        public int OrderBy { get; set; }
        public int PackageId { get; set; }
        public virtual Package Package { get; set; }
    }
}