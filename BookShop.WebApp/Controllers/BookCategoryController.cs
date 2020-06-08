using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookShop.WebApp.Models.BookViewModels;
using BookShopIBLL;

namespace BookShop.WebApp.Controllers
{
    public class BookCategoryController : Controller
    {
        // GET: BookCategory
        private IBookCategoryManager _manager;

        public BookCategoryController(IBookCategoryManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public ActionResult CategoryList()
        {
            var list = _manager.GetAllCategory().Select(m =>
                new BookCategoryViewModels()
                {
                    CategoryNo = m.Id,
                    CategoryName = m.Name
                }).ToList();

            return PartialView("_partialCategoryList", list);
        }
    }
}