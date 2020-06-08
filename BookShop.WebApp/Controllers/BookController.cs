using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BookShop.WebApp.Models.BookViewModels;
using BookShopBLL;
using BookShopIBLL;

namespace BookShop.WebApp.Controllers
{
    public class BookController : Controller
    {
        private IBookManager _manager;

        public BookController(IBookManager manager)
        {
            _manager = manager;
        }
        // GET: Book
       
        [HttpPost]
        public async Task< ActionResult> SearchBook(string name)
        {
            var list=await _manager.QueryBooks(name);
            return Json(list);
        }
    }
}