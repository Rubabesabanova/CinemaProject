using OnePageApplication.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnePageApplication.Models;

namespace OnePageApplication.Controllers
{
    public class HomeController : Controller
    {
        private OnePageDbContext db = new OnePageDbContext();

        public ActionResult Index()
        {
            //ViewBag.Menus = db.Menus.ToList().Where(x=>x.IsVisible == true).OrderBy(x=>x.OrderBy);
            ViewBag.Settings = db.Settings.FirstOrDefault();
            HomeViewModel model = new HomeViewModel
            {
                Features = db.Features.ToList(),
                About = db.Abouts.FirstOrDefault(),
                Skills = db.Skills.ToList(),
                Categories = db.Categories.ToList(),
                Projects = db.Projects.ToList()
            };
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}