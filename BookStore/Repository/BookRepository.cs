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
