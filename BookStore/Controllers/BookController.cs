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
        private readonly LanguageRepository _languageRepository = null;

        public BookController(BookRepository bookRepository, LanguageRepository languageRepository)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
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

        public async Task<ViewResult> AddNewBook()
        {
            ViewBag.Languages = await _languageRepository.GetAllLanguages();

            return View();
        }

        [HttpPost]
        public async Task<ViewResult> AddNewBook(BookModel bookModel)
        {

            ViewBag.Languages = await _languageRepository.GetAllLanguages();

            if (ModelState.IsValid)
            {
                await _bookRepository.AddNewBook(bookModel);
            }
            
            return View();
        }

    }
}
