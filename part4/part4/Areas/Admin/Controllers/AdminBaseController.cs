using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace part4.Areas.Admin.Controllers
{
    public class AdminBaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["UserId"] == null || Session["UserId"].ToString() == null)
            {
                filterContext.Result =
                    new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { area = "admin", controller = "login", action = "index" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}