using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShopIDAL;
using BookShopMODEL;

namespace BookShopDAL
{
    public class OrderServer:BaseServer<Orders>,IOrderServer
    {
        public  OrderServer() : base(new BookShopContext() )
        {

        }
    }
}
