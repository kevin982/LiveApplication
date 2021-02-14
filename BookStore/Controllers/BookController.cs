using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Repository;
using BookStore.Models;
using BookStore.Data.Entities;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {

        private readonly BookRepository _bookRepository = null;

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<ViewResult> GetAllBooks()
        {

            var data = await _bookRepository.GetAllBooks();

            return View(data);
        }

        public async Task<ViewResult> GetBook(int id)
        {
            var data= await _bookRepository.GetBookById(id);
            return View(data);
        }

        public ViewResult AddNewBook()
        {
            ViewBag.Languages = new string[] { "English", "Spanish", "French" };

            return View();
        }

        [HttpPost]
        public async Task<ViewResult> AddNewBook(BookModel bookModel)
        {

            ViewBag.Languages = new string[] { "English", "Spanish", "French" };

            if (ModelState.IsValid)
            {
                await _bookRepository.AddNewBook(bookModel);
            }

            
            return View();
        }

    }
}
