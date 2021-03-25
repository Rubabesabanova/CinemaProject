using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MovieProject.Models;
using MovieProject.Models.ViewModels;
using MovieProject.Security;

namespace MovieProject.Controllers
{
    public class AuthController : Controller
    {
        private CinemaDbContext db = new CinemaDbContext();

        // GET: Auth
        [Route("Auth")]
        public ActionResult Index(User usr)
        {
            usr= usr ?? new User() { };
            try
            {

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return View(usr);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Name,Surname,Email,Password")] User user)
        {
            Session["EmailUnique"] = true;
            if (EmailIsUnique(user.Email))
            {
                Session["EmailUnique"] = null;
                if (ModelState.IsValid)
                {
                    try
                    {
                        user.Password = Crypto.HashPassword(user.Password);
                        db.Users.Add(user);
                        db.SaveChanges();
                        Session["Logined"] = true;
                        Session["User"] = user.Name;
                        Session["UserId"] = user.Id;
                        return RedirectToAction("Index", "Home");
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
            }
            
            return RedirectToAction("Index", user);
        }

        [HttpPost]
        public bool EmailIsUnique(string email)
        {
            foreach (var item in db.Users)
            {
                if (item.Email==email)
                {
                    return false;
                }
            }
            return true;
        }

        [Route("Auth/Login")]
        public ActionResult Login(User usr)
        {
            usr = usr ?? new User() { };
            try
            {

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return View(usr);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginView([Bind(Include = "Email,Password")] User user)
        {
                try
                {
                    User usr = db.Users.FirstOrDefault(x => x.Email == user.Email);
                    if (usr != null)
                    {
                        if (Crypto.VerifyHashedPassword(usr.Password, user.Password))
                        {
                            Session["Logined"] = true;
                            Session["User"] = usr.Name;
                            Session["UserId"] = usr.Id;
                            return RedirectToAction("Index", "Home");
                        }
                    }
                
                    Session.Timeout = 1;
                    return RedirectToAction("Login", user);
                }
                catch (Exception)
                {
                    throw;
                }

            return RedirectToAction("Login", user);
        }

        public ActionResult Logout(User usr)
        {
            Session["Logined"] = null;
            Session["User"] = null;
            Session["UserId"] = null;
            return RedirectToAction("Login");
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
