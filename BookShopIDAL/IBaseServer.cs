using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 *类名称：IBaseServer
 *类描述：
 *创建人：ASUS
 *创建时间：2020-05-29 09:58:40
 *修改人：ASUS
 *修改时间：2020-05-29 09:58:40
 */

namespace BookShopIDAL
{
    public interface IBaseServer<T> where T : class
    {
        Task<int> InsertAsync(T model);
        Task<T> QueryAsync(int id);
        Task<int> UpdateAsync(T model);
        Task<int> DeleteAsync(T model);
        IQueryable<T> QueryAll();
    }
}
