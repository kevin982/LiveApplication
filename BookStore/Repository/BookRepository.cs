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
            Book book = new() {ImageUrl = bookModel.ImageUrl ,LanguageId=bookModel.Language, Author = bookModel.Author, Category = bookModel.Category, Description = bookModel.Description, Pages = bookModel.Pages, Title = bookModel.Title, CreatedOn = DateTime.UtcNow, UpddatedOn = DateTime.UtcNow };

            await context.AddAsync(book);
            await context.SaveChangesAsync();

            return book.Id;
        }


        public async Task<List<BookModel>> GetAllBooks()
        {
            List<Book> result = await context.Books.AsNoTracking().ToListAsync();

            List<BookModel> list = new();

            foreach (var book in result)
            {
                list.Add(new BookModel() { Id = book.Id, Author = book.Author, Description = book.Description, ImageUrl = book.ImageUrl});
            }

            return list;
        }

        public async Task<BookModel> GetBookById(int id)
        {

            Book result = await context.Books.AsNoTracking().Include(b => b.Language).FirstAsync(book => book.Id == id);

            return new BookModel() { Pages = result.Pages ,Author= result.Author, Description = result.Description, Title = result.Title, Language = result.Language.Id, LanguageName = result.Language.Name, Category = result.Category, ImageUrl = result.ImageUrl};
        }


    }
}
