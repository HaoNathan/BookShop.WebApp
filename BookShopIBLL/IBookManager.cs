using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShopDto;
using BookShopMODEL;


/*
 *类名称：IBookManager
 *类描述：
 *创建人：ASUS
 *创建时间：2020-06-01 17:25:19
 *修改人：ASUS
 *修改时间：2020-06-01 17:25:19
 */

namespace BookShopIBLL
{
    public interface IBookManager
    {
        Task<List<Books>> GetAllBook();
        Task<List<BooksDto>> QueryBooks(string name);
    }
}
