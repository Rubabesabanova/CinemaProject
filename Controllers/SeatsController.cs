using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieProject.Models;
using MovieProject.Models.ViewModels;
using MovieProject.Security;

namespace MovieProject.Controllers
{
    public class SeatsController : Controller
    {
        private CinemaDbContext db = new CinemaDbContext();
        // GET: Seats
        [Route("Seats", Name = "SeatIndex")]
        public ActionResult Index(int? id)
        {

            SeatViewModel viewModel = null;
            try
            {
                if (id == null)
                {
                    viewModel = new SeatViewModel
                    {
                        Seats = db.Seats.ToList(),
                        SeatSingle = new List<Seat>() { },
                        Halls = db.Halls.ToList(),
                        Seat = new Seat() { },
                        SeatId = 0
                    };
                }
                else
                {
                    var seat = db.Seats.Where(x => x.Id == id).FirstOrDefault();
                    viewModel = new SeatViewModel
                    {
                        Seats = db.Seats.ToList(),
                        Halls = db.Halls.ToList(),
                        SeatSingle = new List<Seat>() { seat },
                        Seat = new Seat() { },
                        SeatId = id
                    };
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return View(viewModel);
        }


    }
}