using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieProject.Models;
using MovieProject.Security;

namespace MovieProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CinemaViewModel viewModel = null;
            try
            {
                using (CinemaDbContext cinemaDbContext = new CinemaDbContext())
                {
                    viewModel = new CinemaViewModel
                    {
                        Movies = cinemaDbContext.Movies.ToList(),
                        Genres = cinemaDbContext.Genres.ToList(),
                        Countries = cinemaDbContext.Countries.ToList(),
                    };
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return View(viewModel);
        }

        public ActionResult Detail(int id)
        {
            using (CinemaDbContext db = new CinemaDbContext())
            {
                var movie = db.Movies.Where(x => x.Id == id).FirstOrDefault();
                if (movie == null)
                {
                    return View("~/Views/Errors/Errors.cshtml");
                }
                return View(movie);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Filter(DateTime? fromDate, DateTime? toDate)
        {

            CinemaViewModel viewModel = null;
            try
            {
                using (CinemaDbContext cinemaDbContext = new CinemaDbContext())
                {
                    fromDate = fromDate == null ? DateTime.MinValue : fromDate;
                    toDate = toDate == null ? DateTime.MaxValue : toDate;
                    viewModel = new CinemaViewModel
                    {
                        Movies = cinemaDbContext.Movies.Where(x=> x.PublicationDate>=fromDate && x.PublicationDate<=toDate).ToList(),
                        Genres = cinemaDbContext.Genres.ToList(),
                        Countries = cinemaDbContext.Countries.ToList(),
                    };
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return View(viewModel);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}