using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Generator;
using System.Web.UI;
using BookShop.WebApp.Areas.Admin.Models.UserViewModel;
using BookShop.WebApp.Utility;
using BookShopIBLL;
using BookShopMODEL;

namespace BookShop.WebApp.Areas.Admin.Controllers
{
    public class UserManagerController : Controller
    {
        private IUserManager _manager;

        public UserManagerController(IUserManager manager)
        {
            _manager = manager;
        }

        // GET: Admin/UserManager
        [HttpGet]
        public ActionResult UserList()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetUserList(int page, int limit, string userName, string userPhone,
            string userEmail)
        {
            var list = await _manager.GetAllUser();
            if (!string.IsNullOrEmpty(userName))
                list = list.Where(m => m.Name.Contains(userName)).ToList();
            if (!string.IsNullOrEmpty(userPhone))
                list = list.Where(m => m.Phone.Contains(userPhone)).ToList();
            if (!string.IsNullOrEmpty(userEmail))
                list = list.Where(m => m.Mail.Contains(userEmail)).ToList();
            var count = list.Count();
            var data = list.Select(m => new
            {
                m.LoginId,
                m.Address,
                m.Mail,
                m.Name,
                m.Phone,
                userStateName = m.UserStateId
            }).ToList().Skip((page - 1) * limit).Take(limit);
            ReturnMsg result = new ReturnMsg()
            {
                Data = data,
                IsSuccess = true,
                Info = count.ToString()
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateUserState(string loginId, int stateId)
        {
            var result = await _manager.UpdateUserState(loginId, stateId);
            ReturnMsg msg = new ReturnMsg();

            if (result == 1)
            {
                msg.IsSuccess = true;
                msg.Info = "成功";
            }

            return Json(msg);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(string loginId)
        {
            var result = await _manager.DeleteUser(loginId);
            ReturnMsg msg = new ReturnMsg();
            if (result==1)
            {
                msg.IsSuccess = true;
                msg.Info = "删除成功";
            }

            return Json(msg);
        }
        [HttpGet]
        public  ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Add(UserListViewModel user)
        {
            var result = await _manager.InsertUser(new Users()
            {
                LoginId = user.LoginId,
                LoginPwd = user.LoginPwd,
                Name = user.Name,
                Address = user.Address,
                Phone = user.Phone,
                Mail = user.Mail,
                Birthday = user.Birthday,
                UserRoleId = 1,
                UserStateId =1,
                RegisterTime = DateTime.Now
            });
            ReturnMsg msg=new ReturnMsg();
            if (result==1)
            {
                msg.IsSuccess = true;
                msg.Info = "添加成功";
            }

            return Json(msg);
        }
        [HttpGet]
        public async Task<ActionResult> UpdateUser(string loginId)
        {
            var user= await _manager.QueryUserByName(loginId);
            return View(new UserListViewModel()
            {
                UserRoleId = user.UserRoleId,
                LoginId = user.LoginId,
                Address = user.Address,
                Name = user.Name,
                Mail = user.Mail,
                Birthday = user.Birthday.HasValue ? user.Birthday.Value : Convert.ToDateTime("1900-1-1"),
                Phone = user.Phone,
            });
        }
        [HttpGet]
        public async Task<ActionResult> Detail(string loginId)
        {
              var user=  await _manager.QueryUserByName(loginId);
              UserListViewModel users=new UserListViewModel()
              {
                  UserRoleId = user.UserRoleId,
                  LoginId = user.LoginId,
                  Address = user.Address,
                  Name = user.Name,
                  Mail = user.Mail,
                  Birthday = user.Birthday.HasValue?user.Birthday.Value:Convert.ToDateTime("1900-1-1"),
                  Phone = user.Phone,
                  
              };
              return View(users);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateUser(UserListViewModel user)
        {
            var data = await _manager.QueryUserByName(user.LoginId);
            data.LoginId = user.LoginId;
            data.LoginPwd = user.LoginPwd;
            data.Name = user.Name;
            data.Address = user.Address;
            data.Phone = user.Phone;
            data.Mail = user.Mail;
            data.Birthday = user.Birthday;
            data.UserRoleId = user.UserRoleId;
            var result = await _manager.UpdateUser(data);
            ReturnMsg msg = new ReturnMsg();
            if (result == 1)
            {
                msg.IsSuccess = true;
                msg.Info = "修改成功";
            }
            return Json(msg);
        }
    }
}