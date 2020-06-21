using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BookShop.WebApp.Areas.Admin.Models.BookViewModel;
using BookShop.WebApp.Utility;
using BookShopIBLL;

namespace BookShop.WebApp.Areas.Admin.Controllers
{
    public class BookManagerController : Controller
    {
        // GET: Admin/BookManager
        private readonly IBookManager _manager;

        public BookManagerController(IBookManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task< ActionResult> BookList()
        {
            var data = await _manager.GetAllCategory();
            ViewBag.CategoryName =new SelectList(data, "Id", "Name");
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> GetBookList(int page, int limit, string bookTitle, string author,string categoryId)
        {
            var list = await _manager.GetAllBook();
            if (!string.IsNullOrEmpty(bookTitle))
                list = list.Where(m => m.Title.Contains(bookTitle)).ToList();
            if (!string.IsNullOrEmpty(author))
                list = list.Where(m => m.Author.Contains(author)).ToList();
            if (!string.IsNullOrEmpty(categoryId))
                list = list.Where(m => m.CategoryId.ToString().Equals(categoryId)).ToList();
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

        [HttpGet]
        public ActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(BookViewModel model)
        {
            ReturnMsg msg=new ReturnMsg();
            return View();
        }
    }
}