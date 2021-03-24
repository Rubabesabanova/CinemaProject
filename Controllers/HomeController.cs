using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieProject.Filters;
using MovieProject.Models;
using MovieProject.Models.ViewModels;
using MovieProject.Security;

namespace MovieProject.Controllers
{
    public class HomeController : Controller
    {
        CinemaDbContext cinemaDbContext = new CinemaDbContext();

        [Auth]
        public ActionResult Index(DateTime? FromDate, DateTime? ToDate)
        {
            IndexViewModel viewModel = null;
            try
            {
                    viewModel = new IndexViewModel
                    {
                        Movies = cinemaDbContext.Movies.ToList(),
                        Genres = cinemaDbContext.Genres.ToList(),
                        Countries = cinemaDbContext.Countries.ToList(),
                        MovieGenres = cinemaDbContext.MovieGenres.ToList(),
                        MovieCountries = cinemaDbContext.MovieCountries.ToList(),
                        MovieId = 0
                    };
                DateTime? fromDate = FromDate == null ? DateTime.MinValue : FromDate;
                DateTime? toDate = ToDate == null ? DateTime.MaxValue : ToDate;
                    viewModel.Movies = cinemaDbContext.Movies.Where(x => x.PublicationDate >= fromDate && x.PublicationDate <= toDate).ToList();
                    viewModel.start = FromDate;
                    viewModel.end = ToDate;

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return View(viewModel);
        }
        [Auth]
        public ActionResult Detail(int id)
        {
            
                var movie = cinemaDbContext.Movies.Where(x => x.Id == id).FirstOrDefault();
                if (movie == null)
                {
                    return View("~/Views/Errors/Errors.cshtml");
                }
                return View(movie);
           
        }
        [Auth]
        [Route("Home/Movies/Add", Name ="AddMovie")]
        [Route("Home/Movies/{id:int}/Edit", Name ="EditMovie")]
        public ActionResult AddorUpdateMovie(int? id)
        {
            IndexViewModel viewModel = null;
            try
            {
                if (id == null)
                {
                    viewModel = new IndexViewModel
                    {
                        Movies = cinemaDbContext.Movies.ToList(),
                        Genres = cinemaDbContext.Genres.ToList(),
                        Countries = cinemaDbContext.Countries.ToList(),
                        MovieGenres = cinemaDbContext.MovieGenres.ToList(),
                        MovieCountries = cinemaDbContext.MovieCountries.ToList(),
                        MovieId = 0
                    };
                }
                else
                {
                    var movie = cinemaDbContext.Movies.Where(x => x.Id == id).FirstOrDefault();
                    viewModel = new IndexViewModel
                    {
                        Movies = new List<Movie>() { movie },
                        Genres = cinemaDbContext.Genres.ToList(),
                        Countries = cinemaDbContext.Countries.ToList(),
                        MovieGenres = cinemaDbContext.MovieGenres.ToList(),
                        MovieCountries = cinemaDbContext.MovieCountries.ToList(),
                        MovieId = id
                    };
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddorUpdate(Movie movie, int[] Countries, int[] Genres)
        {

            cinemaDbContext.Movies.AddOrUpdate(movie);
            cinemaDbContext.SaveChanges();
            DeleteRelations(movie.Id);
            foreach (int country in Countries)
            {
                MovieCountry movieCountry = new MovieCountry
                {
                    MovieId = movie.Id,
                    CountryId = country
                };

                cinemaDbContext.MovieCountries.Add(movieCountry);
                cinemaDbContext.SaveChanges();
               
            }

            foreach (int genre in Genres)
            {
                MovieGenre movieGenre = new MovieGenre
                {
                    MovieId = movie.Id,
                    GenreId = genre
                };

                cinemaDbContext.MovieGenres.Add(movieGenre);
                cinemaDbContext.SaveChanges();
               
            }
            return RedirectToAction("Index");
        }
        [Auth]
        [Route("Home/Movies/{id:int}/Delete", Name = "DeleteMovie")]
        public ActionResult Delete(int id)
        {
            var item = cinemaDbContext.Movies.Where(x => x.Id == id).FirstOrDefault();
            cinemaDbContext.Movies.Remove(item);
            cinemaDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        private void DeleteRelations(int id)
        {
            foreach (MovieGenre item in cinemaDbContext.MovieGenres.Where(x => x.MovieId == id).ToList())
            {
                cinemaDbContext.MovieGenres.Remove(item);
                cinemaDbContext.SaveChanges();
            }
            foreach (MovieCountry item in cinemaDbContext.MovieCountries.Where(x => x.MovieId == id).ToList())
            {
                cinemaDbContext.MovieCountries.Remove(item);
                cinemaDbContext.SaveChanges();
            }
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
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                cinemaDbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}