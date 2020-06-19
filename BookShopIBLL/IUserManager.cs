using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShopMODEL;
/*
 *类名称：UserManager
 *类描述：
 *创建人：ASUS
 *创建时间：2020-05-30 13:51:57
 *修改人：ASUS
 *修改时间：2020-05-30 13:51:57
 */

namespace BookShopIBLL
{
    public interface IUserManager
    {
        Task<bool>  Login(string userName,string userPwd);
        Task<int> Register(Users user);
        Task<List<Users>> GetAllUser();
        Task<Users> QueryUserByName(string name);
        Task<int> UpdateUserState(string name,int state);
        Task<int> UpdateUser(Users user);
        Task<int> DeleteUser(string name);
        Task<int> InsertUser(Users user);
    }
}
