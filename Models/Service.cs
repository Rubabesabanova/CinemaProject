using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnePageApplication.Models
{
    public class Service : BaseClass
    {
        public Service()
        {
            this.ServiceElements = new HashSet<ServiceElement>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ServiceElement> ServiceElements { get; set; }
    }
}