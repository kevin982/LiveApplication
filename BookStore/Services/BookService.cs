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
    public class BookService : IBookService
    {
        private readonly BookStoreContext context = null;

        public BookService(BookStoreContext _context)
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

            return (BookModel)book.Clone();
        }

        public async Task<List<BookModel>> GetTopBooksAsync(int count)
        {
            List<Book> Books = await context.Books.AsNoTracking().Include(b => b.Language).Include(b => b.Images).Take(count).ToListAsync();

            List<BookModel> BooksModel = new();

            foreach (var book in Books)
            {
                BooksModel.Add((BookModel)book.Clone());
            }

            return BooksModel;
        }

        public async Task<List<BookModel>> GetRelatedBooksAsync(int id, string category, int count)
        {
            List<Book> Books = await context.Books.AsNoTracking().Include(b => b.Language).Include(b => b.Images).Where(b => b.Category == category && b.Id != id).ToListAsync();

            List<BookModel> BooksModel = new();

            var positions = GetRandomBooks(count, Books.Count);

            for (int i = 0; i < positions.Count; i++)
            {
                BooksModel.Add((BookModel)Books[positions[i]].Clone());
            }

            return BooksModel;

        }

        private List<int> GetRandomBooks(int count, int size)
        {
            Random random = new();
            var positions = new List<int>();
            int counter = 0;

            for (int i = 0; i < size; i++)
            {
                bool continuar = true;

                while (continuar)
                {
                    int number = random.Next(0, size - 1);
    
                    if (!positions.Contains(number))
                    {
                        continuar = false;
                        positions.Add(number);
                        counter++;
                    }
                }

                if (counter == count) break;
            }

            return positions;

        }

 
    }
}
