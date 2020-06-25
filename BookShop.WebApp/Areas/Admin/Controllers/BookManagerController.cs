using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BookShop.WebApp.Areas.Admin.Models.BookViewModel;
using BookShop.WebApp.Utility;
using BookShopIBLL;
using BookShopMODEL;

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
        public async Task<ActionResult> AddBook()
        {
            var data = await _manager.GetAllCategory();
            ViewBag.CategoryNames = new SelectList(data, "Id", "Name");
            var data1 = await _manager.GetAllPublisher();
            ViewBag.PubulishNames = new SelectList(data1, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public async Task< ActionResult> AddBook(BookViewModel model,string imageUrl)
        {
            var result=await _manager.InsertBook( new Books()
            {
                Title = model.Title,
                Author = model.Author,
                CategoryId = model.CategoryId,
                PublishDate = model.PublishDate,
                ISBN = model.ISBN,
                PublisherId = model.PublisherId,
                UnitPrice = model.UnitPrice,
                TOC = model.TOC,
                ContentDescription = model.ContentDescription
            });
          
                DirectoryInfo dr=new DirectoryInfo(Server.MapPath("~/Areas/Admin/Asset/BookCovers"));
                foreach (var item in dr.GetFiles())
                {
                    if (item.Name == imageUrl.Substring(imageUrl.LastIndexOf("/") + 1))
                    {
                        string newPath = Server.MapPath("~/Areas/Admin/Asset/BookCovers/") + model.ISBN + item.Extension;
                        if (System.IO.File.Exists(newPath))
                        {
                            System.IO.File.Delete(newPath);
                        }
                        item.MoveTo(newPath);
                        break;
                    }
                }
            
            ReturnMsg msg=new ReturnMsg();
            if (result==1)
            {
                msg.IsSuccess = true;
                msg.Info = "新增成功";
            }
            return Json(msg);
        }

        public ActionResult UploadFile(HttpPostedFileBase file)
        {

            if (file != null && !string.IsNullOrEmpty(file.FileName))
            {
                string newName = Guid.NewGuid().ToString("n") + "_" + file.FileName;
                string path = Server.MapPath("~/Areas/Admin/Asset/BookCovers ");
                file.SaveAs(Path.Combine(path, newName));
                string displayPath = "/Areas/Admin/Asset/BookCovers/" + newName;
                return Json(new {code = 0, data = displayPath, msg = "成功"});
            }

            return Json(new {code = 1, msg = "error", data = ""});
        }
        public ActionResult UploadDetailFile(HttpPostedFileBase file)
        {

            if (file != null && !string.IsNullOrEmpty(file.FileName))
            {
                string newName = Guid.NewGuid().ToString("n") + "_" + file.FileName;
                string path = Server.MapPath("/Areas/Admin/Asset/DetailImage ");
                file.SaveAs(Path.Combine(path, newName));
                string displayPath = "/Areas/Admin/Asset/DetailImage/" + newName;
                return Json(new { code = 0, data =new{src= displayPath,title=newName } , msg = "成功" });
            }

            return Json(new { code = 1, msg = "error", data =new{src="" } });
        }

        public async Task<ActionResult> DeleteBook(string id)
        {
            ReturnMsg msg=new ReturnMsg();
            var result = await _manager.DeleteBook(id);
            if (result==1)
            {
                msg.IsSuccess = true;
                msg.Info = "删除成功";
            }

            return Json(msg);
        }
    }
}