using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(n => n.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(n => n.Title == title && n.Author.Contains(authorName)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id = 1, Title="MVC", Author = "Nitish"},
                new BookModel(){Id = 2, Title="MVC", Author = "Nitish"},
                new BookModel(){Id = 3, Title="C#", Author = "Monika"},
                new BookModel(){Id = 4, Title="Java", Author = "Webgentle"},
                new BookModel(){Id = 5, Title="Php", Author = "WebGentle"}
            };
        }
    }
}
