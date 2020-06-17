using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.WebApp.Areas.Admin.Controllers
{
    public class MainController : Controller
    {
        // GET: Admin/Main
       
        public ActionResult Main()
        {
            return View();
        }
    }
}