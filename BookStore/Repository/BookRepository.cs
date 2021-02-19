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
        public async Task AddBookAsync(BookModel bookModel)
        {
            Book book = (Book)bookModel.Clone();
            book.CreatedOn = DateTime.UtcNow;
            book.UpddatedOn = DateTime.UtcNow;
 
            await context.AddAsync(book);
            await context.SaveChangesAsync();
        }


        public async Task<List<BookModel>> GetAllBookAsync()
        {
            List<Book> Books = await context.Books.AsNoTracking().Include(b => b.Language).Include(b => b.Images).ToListAsync();

            List<BookModel> BooksModel = new();

            foreach (var book in Books)
            {
                BooksModel.Add((BookModel)book.Clone());
            }

            return BooksModel;
        }

        public async Task<BookModel> GetBookByIdAsync(int id)
        {
            Book book = await context.Books.AsNoTracking().Include(b => b.Language).Include(b => b.Images).FirstAsync(book => book.Id == id);
 
            return (BookModel) book.Clone();
        }

        public async Task<List<BookModel>> GetTopBooksAsync()
        {
            List<Book> Books = await context.Books.AsNoTracking().Include(b => b.Language).Include(b => b.Images).Take(5).ToListAsync();

            List<BookModel> BooksModel = new();

            foreach (var book in Books)
            {
                BooksModel.Add((BookModel)book.Clone());
            }

            return BooksModel;
        }


    }
}
