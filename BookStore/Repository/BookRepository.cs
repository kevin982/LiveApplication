using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Data.Entities;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext context = null;

        public BookRepository(BookStoreContext _context)
        {
            context = _context;
        }

        public async Task<int> AddNewBook(BookModel bookModel)
        {
            Book book = new() { Author = bookModel.Author, Category = bookModel.Category, Description = bookModel.Description, Pages = bookModel.Pages, Title = bookModel.Title, CreatedOn = DateTime.UtcNow, UpddatedOn = DateTime.UtcNow };

            await context.AddAsync(book);
            await context.SaveChangesAsync();

            return book.Id;
        }


        public async Task<List<Book>> GetAllBooks()
        {
            List<Book> result = new();

            result = await context.Books.AsNoTracking().ToListAsync();

            return result;
        }

        public async Task<Book> GetBookById(int id)
        {
            Book result;

            result = await context.Books.AsNoTracking().FirstAsync(book => book.Id == id);

            return result;

        }


    }
}
