using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TAMS.Entity;
namespace TAMS.Areas.Admin.Controllers
{
    public class SessionController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (Account)Session[Common.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new {
                    Controller = "Login",
                    action ="Index",
                    Areas = "Admin"
                }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}