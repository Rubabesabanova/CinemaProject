using OnePageApplication.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnePageApplication.Areas.Manage.Controllers
{
    public class HomeController : Controller
    {
        private OnePageDbContext db = new OnePageDbContext();

        // GET: Manage/Home
        public ActionResult Index()
        {
            return View();
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