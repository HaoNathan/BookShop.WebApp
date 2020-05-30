using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookShop.WebApp.Models;
using  BookShopTOOL;

namespace BookShop.WebApp.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModels models)
        {
            if (ModelState.IsValid)
            {
                return View("About");
            }
            else
            {
                return View("index",models);
            }

        }

        [Filter.BookShopAuth]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult GetCode()
        {
            string strImageCode = string.Empty;
            byte[] codeImage= PublicHelper.GetImageCode(out strImageCode);

            return File(codeImage, "image/jpeg");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}