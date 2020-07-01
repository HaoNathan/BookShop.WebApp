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
        public async Task<ActionResult> GetOrderGroupByDate(string beginDate,string endDate)
        {
            var orderList = await _manager.GetAllOrder();
            var begin = Convert.ToDateTime(beginDate);
            var end = Convert.ToDateTime(endDate);

            var orderGroup = orderList.Where(m=>m.OrderDate>=begin&&m.OrderDate<=end)
                .GroupBy(m => m.OrderDate.Month)
                .Select(m => new
            {
                name = m.Key,
                y = m.Count()
            });

            List<string>nameList=new List<string>();
            List<int>countList=new List<int>();
            Dictionary<string,object> dic=new Dictionary<string, object>();

            foreach (var item in orderGroup)
            {
                nameList.Add(item.name+"月");
                countList.Add(item.y);
            }
            dic.Add("list1",nameList);
            dic.Add("list2", countList);

            return Json(dic);
        }
        public async Task<ActionResult> GetOrderGroupByDate()
        {
            var orderList = await _manager.GetAllOrder();
            //var begin = Convert.ToDateTime(beginDate);
            //var end = Convert.ToDateTime(endDate);

            //var orderGroup = orderList.Where(m => m.OrderDate >= begin && m.OrderDate <= end)
            //    .GroupBy(m => m.OrderDate.Month)
            //    .Select(m => new
            //    {
            //        name = m.Key,
            //        y = m.Count()
            //    });

            //List<string> nameList = new List<string>();
            //List<int> countList = new List<int>();
            //Dictionary<string, object> dic = new Dictionary<string, object>();

            //foreach (var item in orderGroup)
            //{
            //    nameList.Add(item.name + "月");
            //    countList.Add(item.y);
            //}
            //dic.Add("list1", nameList);
            //dic.Add("list2", countList);

            return Json(null);
        }

    }
}