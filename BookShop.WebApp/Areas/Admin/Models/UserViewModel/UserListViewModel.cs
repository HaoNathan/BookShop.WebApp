using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.WebApp.Areas.Admin.Models.UserViewModel
{
    public class UserListViewModel
    {

        public string LoginId { get; set; }

        public string LoginPwd { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Mail { get; set; }

        public DateTime? Birthday { get; set; }

        public int UserRoleId { get; set; }

        public int UserStateId { get; set; }

        public string RegisterIp { get; set; }

        public DateTime? RegisterTime { get; set; }
    }
}