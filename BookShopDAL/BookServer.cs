using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShopIDAL;
using BookShopMODEL;


/*
 *类名称：BookServer
 *类描述：
 *创建人：ASUS
 *创建时间：2020-06-02 15:24:34
 *修改人：ASUS
 *修改时间：2020-06-02 15:24:34
 */

namespace BookShopDAL
{
    public class BookServer:BaseServer<Books>,IBookServer
    {
        public BookServer() : base(new BookShopContext())
        {
        }
    }
}
