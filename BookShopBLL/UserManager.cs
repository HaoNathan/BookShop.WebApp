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
 *类名称：UserManager
 *类描述：
 *创建人：ASUS
 *创建时间：2020-05-30 13:52:53
 *修改人：ASUS
 *修改时间：2020-05-30 13:52:53
 */

namespace BookShopBLL
{
    public class UserManager:IUserManager
    {
        public  async Task<bool> Login(string userName, string userPwd)
        {
            using (IUserServer userServer=new UserServer())
            {
                return await userServer.QueryAll().AnyAsync(m => m.LoginId == userName && m.LoginPwd == userPwd);
            }
        }

        public async Task<int> Register(Users user)
        {

            using (IUserServer userServer=new UserServer())
            {
                return await userServer.InsertAsync(user);
            }
        }
    }
}
