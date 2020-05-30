using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShopMODEL;


/*
 *类名称：UserServer
 *类描述：
 *创建人：ASUS
 *创建时间：2020-05-30 13:53:28
 *修改人：ASUS
 *修改时间：2020-05-30 13:53:28
 */

namespace BookShopDAL
{
    public class UserServer : BaseServer<BookShopMODEL.Users>
    {
        public UserServer() : base(new BookShopContext())
        {
        }
    }
}
