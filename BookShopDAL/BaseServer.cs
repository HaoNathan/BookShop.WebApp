using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  BookShopIDAL;


/*
 *类名称：BaseServer
 *类描述：
 *创建人：ASUS
 *创建时间：2020-05-29 09:59:12
 *修改人：ASUS
 *修改时间：2020-05-29 09:59:12
 */

namespace BookShopDAL
{
    public class BaseServer<T>:IBaseServer<T> where T :class,new()
    {
        
        public async Task<int> InsertAsync(T model)
        {
            throw new NotImplementedException();
        }

        public async Task<T> QueryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(T model)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(T model)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> QueryAll()
        {
            throw new NotImplementedException();
        }
    }
}
