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
    public class SeatsController : Controller
    {
        private CinemaDbContext db = new CinemaDbContext();
        // GET: Seats
        [Auth]
        [Route("Seats/Index", Name = "SeatIndex")]
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HallId,Row,Column")] Seat seat)
        {
            Session["SeatUnique"] = true;
            if (SeatIsUnique(seat.HallId, seat.Row))
            {
                Session["SeatUnique"] = null;
                if (ModelState.IsValid)
                {
                    seat.Row = seat.Row.ToUpper();
                    db.Seats.Add(seat);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public bool SeatIsUnique(int id, string row)
        {
            foreach (var item in db.Seats)
            {
                if (item.HallId == id && item.Row == row)
                {
                    return false;
                }
            }
            return true;
        }

        [HttpPost]
        public bool SeatIsUnique(int id, string row, int seatid)
        {
            foreach (var item in db.Seats)
            {
                if (item.Id!=seatid && item.HallId == id && item.Row == row)
                {
                    return false;
                }
            }
            return true;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "Id,HallId,Row,Column")] Seat seat)
        {
            Session["SeatUnique"] = true;
            if (SeatIsUnique(seat.HallId, seat.Row, seat.Id))
            {
                Session["SeatUnique"] = null;
                if (ModelState.IsValid)
                {
                    seat.Row = seat.Row.ToUpper();
                    db.Seats.AddOrUpdate(seat);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        [Auth]
        [Route("Home/Seats/{id:int}/Delete", Name = "DeleteSeat")]
        public ActionResult Delete(int id)
        {
            var item = db.Seats.Where(x => x.Id == id).FirstOrDefault();
            db.Seats.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}