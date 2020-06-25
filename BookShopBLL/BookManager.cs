using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShopDAL;
using BookShopDto;
using BookShopIBLL;
using BookShopIDAL;
using BookShopMODEL;

/*
 *类名称：BookManager
 *类描述：
 *创建人：ASUS
 *创建时间：2020-06-02 15:23:14
 *修改人：ASUS
 *修改时间：2020-06-02 15:23:14
 */

namespace BookShopBLL
{
    public class BookManager:IBookManager
    {
        private IBookServer _server;

        public BookManager(IBookServer server)
        {
            _server = server;
        }
        public async Task<List<Books>> GetAllBook()
        {
                return await _server.QueryAll().ToListAsync();
        }

        public async Task<List<BooksDto>> QueryBooks(string name)
        {
            
                return await _server.QueryAll().Where(m=>m.Title.Contains(name)).Select(m=>new BooksDto()
                {
                    BookName = m.Title

                }).ToListAsync();
            
        }

        public async  Task<List<Categories>> GetAllCategory()
        {
            using (IBookCategoryServer server=new BookCategoryServer())
            {
                return await  server.QueryAll().ToListAsync();
            }
        }
        public async Task<List<Publishers>> GetAllPublisher()
        {
            using (IBookPublisherServer server = new BookPublisherServer())
            {
                return await server.QueryAll().ToListAsync();
            }
        }

        public async Task<int> InsertBook(Books model)
        {
            return await _server.InsertAsync(model);
        }

        public async Task<int> DeleteBook(string id)
        {
            return await _server.DeleteAsync(int.Parse(id));
        }
    }
}
