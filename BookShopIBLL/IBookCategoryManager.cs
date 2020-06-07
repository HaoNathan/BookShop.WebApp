using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShopMODEL;


/*
 *类名称：IBookCategoryManager
 *类描述：
 *创建人：ASUS
 *创建时间：2020-06-01 17:34:41
 *修改人：ASUS
 *修改时间：2020-06-01 17:34:41
 */

namespace BookShopIBLL
{
   public  interface IBookCategoryManager
   {
       List<Categories> GetAllCategory();
   }
}
