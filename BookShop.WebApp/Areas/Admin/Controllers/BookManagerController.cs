using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BookShop.WebApp.Utility;
using BookShopIBLL;

namespace BookShop.WebApp.Areas.Admin.Controllers
{
    public class BookManagerController : Controller
    {
        // GET: Admin/BookManager
        private IBookManager _manager;

        public BookManagerController(IBookManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public async Task<ActionResult> GetUserList(int page, int limit, string bookTitle, string author, int categoryId)
        {
            var list = await _manager.GetAllBook();
            if (!string.IsNullOrEmpty(bookTitle))
                list = list.Where(m => m.Title.Contains(bookTitle)).ToList();
            if (!string.IsNullOrEmpty(author))
                list = list.Where(m => m.Author.Contains(author)).ToList();
            if (categoryId!=0)
                list = list.Where(m => m.CategoryId==(categoryId)).ToList();
            var count = list.Count();
            var data = list.Select(m => new
            {
                m.Id,
                m.Title,
                m.ISBN,
                m.Author,
                m.UnitPrice,
                m.PublishDate,
                publishName=m.Publishers.Name,
                categoryName = m.Categories.Name
            }).ToList().Skip((page - 1) * limit).Take(limit);
            ReturnMsg result = new ReturnMsg()
            {
                Data = data,
                IsSuccess = true,
                Info = count.ToString()
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}