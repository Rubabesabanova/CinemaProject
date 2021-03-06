using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieProject.Filters
{
    public class Auth : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Logined"] == null)
            {
                filterContext.Result = new RedirectResult("~/Auth");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
    
}