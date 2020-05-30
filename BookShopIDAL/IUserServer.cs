using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShopMODEL;


/*
 *类名称：IUserServer
 *类描述：
 *创建人：ASUS
 *创建时间：2020-05-30 11:27:01
 *修改人：ASUS
 *修改时间：2020-05-30 11:27:01
 */

namespace BookShopIDAL
{
    /// <summary>
    /// 用户类数据服务
    /// </summary>
    public interface IUserServer:IBaseServer<BookShopMODEL.Users> 
    {
       
    }
}
