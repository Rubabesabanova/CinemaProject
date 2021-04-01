using OnePageApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnePageApplication.Security
{
    public class OnePageDbContext : DbContext
    {
        public OnePageDbContext() : base("onepage") { }
        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Fact> Facts { get; set; }
        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<PackageElement> PackageElements { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceElement> ServiceElements { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<SkillElement> SkillElements { get; set; }

    }
}