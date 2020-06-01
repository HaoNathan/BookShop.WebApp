using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BookShop.WebApp.Models;
using BookShop.WebApp.Models.UserViewModels;
using BookShopBLL;
using BookShopMODEL;
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
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModels models, string isRemenber)
        {
            if (ModelState.IsValid)
            {
                if (await new UserManager().Login(models.UserName, models.UserPwd))
                {
                    Session["UserName"] = models.UserName;
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginError", "账号或密码错误");
                    return View("index", models);
                }
            }
            else
            {
                return View("index", models);
            }
        }



        public ActionResult GetCode()
        {
            string strImageCode = string.Empty;
            byte[] codeImage = PublicHelper.GetImageCode(out strImageCode);

            return File(codeImage, "image/jpeg");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModels models)
        {
            if (ModelState.IsValid)
            {
                int result = await new UserManager().Register(new Users()
                {
                    LoginId = models.UserName,
                    Name = models.Name,
                    LoginPwd = models.UserPwd,
                    Address = models.Adress,
                    Phone = models.Phone,
                    Mail = models.Email,
                    UserRoleId = 1,
                    UserStateId = 1
                });
                if (result != 1)
                {
                    return Content("False");
                }

                return Content("Success");
            }


            return View("Register", models);

        }
    }
}
