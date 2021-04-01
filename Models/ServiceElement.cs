using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnePageApplication.Models
{
    public class ServiceElement: BaseClass
    {
        public string Icon { get; set; }
        public string Description { get; set; }
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
    }
}