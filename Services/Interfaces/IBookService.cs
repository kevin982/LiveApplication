using BookStorePrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorePrueba.Services.Interfaces
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
