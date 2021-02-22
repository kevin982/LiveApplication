using BookStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public interface IBookService
    {
        Task AddBookAsync(BookModel bookModel);
        Task<List<BookModel>> GetAllBookAsync();
        Task<BookModel> GetBookByIdAsync(int id);
        Task<List<BookModel>> GetTopBooksAsync(int count);
        Task<List<BookModel>> GetRelatedBooksAsync(int id, string category, int count);
    }
}