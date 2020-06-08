using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShopDAL;
using BookShopIBLL;
using BookShopIDAL;
using BookShopMODEL;


/*
 *类名称：BookCategoryManager
 *类描述：
 *创建人：ASUS
 *创建时间：2020-06-01 17:26:59
 *修改人：ASUS
 *修改时间：2020-06-01 17:26:59
 */

namespace BookShopBLL
{
    public class BookCategoryManager: IBookCategoryManager
    {
        private IBookCategoryServer _server;

        public BookCategoryManager(IBookCategoryServer server)
        {
            _server = server;
        }
        public  List<Categories> GetAllCategory()
        {
            using (IBookCategoryServer server = new BookCategoryServer())
            {
                return server.QueryAll().ToList();
            }
        }

    }
}
