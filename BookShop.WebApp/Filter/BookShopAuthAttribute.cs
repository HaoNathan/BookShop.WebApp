using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookShop.WebApp.Filter
{
    public class BookShopAuthAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["UserName"]==null||filterContext.HttpContext.Request.Cookies["UserName"]==null)
            {
                filterContext.Result=new RedirectToRouteResult(new RouteValueDictionary()
                {
                    {"controller","Home"},
                    {"action","index"}
                });
            }

            //base.OnAuthorization(filterContext);
        }
    }
}