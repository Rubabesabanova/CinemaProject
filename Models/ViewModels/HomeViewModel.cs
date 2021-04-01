using System;
using System.Collections.Generic;

namespace OnePageApplication.Models
{
    public class HomeViewModel
    {
        public List<Feature> Features { get; set; }
        public About About { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Category> Categories { get; set; }
        public List<Project> Projects { get; set; }
    }
}