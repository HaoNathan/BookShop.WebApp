using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BookShop.WebApp.Models.BookViewModels;
using BookShopBLL;

namespace BookShop.WebApp.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        [HttpGet]
        public  ActionResult  CategoryList()
        {
            var list =new BookCategoryManager().GetAllCategory().Select(m =>
                new BookCategoryViewModels()
                {
                    CategoryNo = m.Id,
                    CategoryName = m.Name
                }).ToList();

            return PartialView("_partialCategoryList",list);
        }
        [HttpPost]
        public async Task< ActionResult> SearchBook(string name)
        {
            var list=await new BookManager().QueryBooks(name);
            return Json(list);
        }
    }
}