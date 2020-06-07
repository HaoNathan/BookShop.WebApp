using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShopIDAL;
using BookShopMODEL;


/*
 *类名称：BookCategoryServer
 *类描述：
 *创建人：ASUS
 *创建时间：2020-06-01 17:31:28
 *修改人：ASUS
 *修改时间：2020-06-01 17:31:28
 */

namespace BookShopDAL
{
    public class BookCategoryServer : BaseServer<Categories>, IBookCategoryServer
    {
        public BookCategoryServer() : base(new BookShopContext())
        {
        }
    }

}
