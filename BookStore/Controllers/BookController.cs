using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Repository;
using BookStore.Models;
using BookStore.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {

        private readonly BookRepository _bookRepository = null;
        private readonly LanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;

        public BookController(BookRepository bookRepository, LanguageRepository languageRepository, IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
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
                string folder = "books/cover";
                folder += Guid.NewGuid().ToString() +"_"+bookModel.Image.FileName;

                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                await bookModel.Image.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

                bookModel.ImageUrl = "/"+folder;

                await _bookRepository.AddNewBook(bookModel);
            }
            
            return View();
        }

    }
}
