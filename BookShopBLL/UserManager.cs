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
        private IUserServer _server;

        public UserManager(IUserServer server)
        {
            _server = server;
        }
        public  async Task<bool> Login(string userName, string userPwd)
        {
                return await _server.QueryAll().AnyAsync(m => m.LoginId == userName && m.LoginPwd == userPwd);
        }

        public async Task<int> Register(Users user)
        {
                return await _server.InsertAsync(user);
        }

        public async Task<List<Users>> GetAllUser()
        {
            return await _server.QueryAll().ToListAsync();
        }

        public async Task<Users> QueryUserByName(string name)
        {
            var data = await _server.QueryAll().ToListAsync();
            return data.Find(m => m.LoginId.Equals(name));
        }

        public async Task<int> UpdateUserState(string name,int state)
        {
            var user = await QueryUserByName(name);
            user.UserStateId = state;
            return await _server.UpdateAsync(user);
        }

        public async Task<int> UpdateUser(Users user)
        {
            return await _server.UpdateAsync(user);
        }

        public async Task<int> DeleteUser(string name)
        {
            var user = await _server.QueryAsync(m => m.LoginId.Equals(name));
            return await _server.DeleteAsync(user);
        }

        public async Task<int> InsertUser(Users user)
        {
            return await _server.InsertAsync(user);
        }
    }
}
