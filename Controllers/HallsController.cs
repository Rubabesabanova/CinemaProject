using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieProject.Filters;
using MovieProject.Models;
using MovieProject.Models.ViewModels;
using MovieProject.Security;

namespace MovieProject.Controllers
{
    public class HallsController : Controller
    {
        private CinemaDbContext db = new CinemaDbContext();

        // GET: Halls
        [Auth]
        [Route("Hall", Name = "Index")]
        public ActionResult Index(int? id)
        {
            
            HallViewModel viewModel = null;
            try
            {
                if (id == null)
                {
                    viewModel = new HallViewModel
                    {
                        Halls = db.Halls.ToList(),
                        HallsSingle = new List<Hall>(){ },
                        HallId = 0
                    };
                }
                else
                {
                    var hall = db.Halls.Where(x => x.Id == id).FirstOrDefault();
                    viewModel = new HallViewModel
                    {
                        Halls = db.Halls.ToList(),
                        HallsSingle = new List<Hall>() { hall },
                        HallId = id
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
        public ActionResult Create([Bind(Include = "Name")] Hall hall)
        {
            Session["HallUnique"] = true;
            if (NameIsUnique(hall.Name.ToLower()))
            {
                Session["HallUnique"] = null;
                if (ModelState.IsValid)
                {
                    hall.Name = hall.Name.ToLower();
                    db.Halls.Add(hall);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public bool NameIsUnique(string name)
        {
            foreach (var item in db.Halls)
            {
                if (item.Name.ToLower() == name)
                {
                    return false;
                }
            }
            return true;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "Id,Name")] Hall hall)
        {
            Session["HallUnique"] = true;
            if (NameIsUnique(hall.Name.ToLower()))
            {
                Session["HallUnique"] = null;
                if (ModelState.IsValid)
                {
                    hall.Name = hall.Name.ToLower();
                    db.Halls.AddOrUpdate(hall);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        [Auth]
        [Route("Home/Halls/{id:int}/Delete", Name = "DeleteHall")]
        public ActionResult Delete(int id)
        {
            var item = db.Halls.Where(x => x.Id == id).FirstOrDefault();
            db.Halls.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
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
