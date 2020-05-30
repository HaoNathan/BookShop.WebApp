﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  BookShopIDAL;
using BookShopMODEL;


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
    public class BaseServer<T>:IBaseServer<T> where T :BookShopContext,new()
    {
        private BookShopContext _context;
        public BaseServer(BookShopContext context)
        {
            _context = context;
        }

        public async Task<int> InsertAsync(T model)
        {
             _context.Set<T>().Add(model);
             return await _context.SaveChangesAsync();
        }

      

        public async Task<int> UpdateAsync(T model)
        {
            _context.Entry(model).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(T model)
        {
            _context.Entry(model).State = EntityState.Deleted;
            return await _context.SaveChangesAsync();
        }

        public async Task<T> QueryAsync(int no)
        {
            return await _context.Set<T>().FindAsync(no);
        }

        public IQueryable<T> QueryAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> DeleteAsync(int no)
        {
            var model = _context.Set<T>().FindAsync(no);
            _context.Entry(model).State = EntityState.Deleted;
            return await _context.SaveChangesAsync();
        }
    }
}
