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
            Book book = new() {Author = bookModel.Author, Category = bookModel.Category, Description = bookModel.Description, Language = bookModel.Language, Pages = bookModel.Pages, Title = bookModel.Title, CreatedOn=DateTime.UtcNow, UpddatedOn=DateTime.UtcNow };

            await using (context)
            {
                context.Add(book);
                await context.SaveChangesAsync();
            };

            return book.Id;
        }


        public async Task<List<Book>> GetAllBooks()
        {
            List<Book> result;

            using(context)
            {
                result = await context.Books.AsNoTracking().ToListAsync();   
            };

            return result;
        }

        public async Task<Book> GetBookById(int id)
        {
            Book result;

            using (context)
            {
                result = await context.Books.AsNoTracking().FirstAsync(book => book.Id==id);
            };

            return result;

        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(n => n.Title == title && n.Author.Contains(authorName)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id = 1, Title="MVC", Author = "Nitish", Description="This is the description for MVC book", Pages= 1000 , Language="English", Category="Arquitecture"},
                new BookModel(){Id = 2, Title="MVC", Author = "Nitish", Description="This is the description for MVC book", Pages= 750, Language="Indi", Category="Arquitecture"},
                new BookModel(){Id = 3, Title="C#", Author = "Monika", Description="This is the description for C# book", Pages= 600, Language="Spanish", Category="Programming"},
                new BookModel(){Id = 4, Title="Java", Author = "Webgentle", Description="This is the description for Java book", Pages= 460, Language="French", Category="Programming"},
                new BookModel(){Id = 5, Title="Php", Author = "WebGentle", Description="This is the description for Php book", Pages= 200, Language="English", Category="Programming"},
                new BookModel(){Id = 6, Title="Azure DevOps", Author = "Nitish", Description="This is the description for Azure DevOps book", Pages=200, Language="English", Category="DevOps"}
            };
        }
    }
}
