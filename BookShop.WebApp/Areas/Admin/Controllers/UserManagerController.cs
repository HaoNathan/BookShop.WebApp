﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.WebApp.Areas.Admin.Controllers
{
    public class UserManagerController : Controller
    {
        // GET: Admin/UserManager
        public ActionResult UserList()
        {
            return View();
        }
    }
}