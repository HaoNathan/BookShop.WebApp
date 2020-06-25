using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BookShopBLL;
using BookShopIBLL;
using BookShopMODEL;

namespace BookShop.WebApp.Areas.Admin.Controllers
{
    public class ReportController : Controller
    {
        private IBookManager _manager;

        public ReportController(IBookManager manager)
        {
            _manager = manager;
        }

        // GET: Admin/Report
        public ActionResult Index()
        {
            return View();
        }

        public async  Task< ActionResult> GetBookCategoryData()
        {
            var categoryList =await  _manager.GetAllBook();

            var categoryGroup = categoryList.GroupBy(m => m.Categories.Name).Select(m=>new
            {
                name=m.Key,
                y=m.Count()
            });

            return Json(categoryGroup);
        }
    }
}