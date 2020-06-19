using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.WebApp.Utility
{
    public class ReturnMsg
    {
        public bool IsSuccess { get; set; } = false;
        public string RedirectUrl { get; set; }
        public object Data { get; set; }
        public string Info { get; set; }
    }
}