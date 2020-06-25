using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using BookShopIDAL;
using BookShopMODEL;

namespace BookShopDAL
{
    public class BookPublisherServer:BaseServer<Publishers>,IBookPublisherServer
    {
        public BookPublisherServer() : base(new BookShopContext())
        {

        }
    }
}
