using BookStorePrueba.Models;
using BookStorePrueba.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorePrueba.Controllers
{
    [Route("[controller]/[action]")]
    public class BookController : Controller
    {

        private readonly IBookService _bookService = null;
        private readonly ILanguageService _languageService = null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;

        public BookController(IBookService bookRepository, ILanguageService languageRepository, IWebHostEnvironment webHostEnvironment)
        {
            _bookService = bookRepository;
            _languageService = languageRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<ViewResult> GetAllBooksAsync()
        {

            var data = await _bookService.GetAllBookAsync();

            return View(data);
        }

        [Route("~/{id:int:min(10):max(100)}")]
        public async Task<ViewResult> GetBookAsync(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            var relatedBooks = await _bookService.GetRelatedBooksAsync(book.Id, book.Category, 2);

            ViewBag.Book = book;
            ViewBag.RelatedBooks = relatedBooks;

            return View();
        }

        public ViewResult AddNewBookAsync()
        {
            return View();
        }

        [HttpPost]
        public async Task<ViewResult> AddNewBookAsync(BookModel bookModel)
        {

            string folder = "";


            if (ModelState.IsValid)
            {

                Task.WaitAll(

                    Task.Run(async () => {

                        folder = "books/cover/";
                        bookModel.CoverImageUrl = await UploadFile(folder, bookModel.Image); //Se agrega la imagen principal

                    }),

                    Task.Run(async () => {

                        folder = "books/pdf/";
                        bookModel.BookPdfUrl = await UploadFile(folder, bookModel.BookPdf);//Se agrega el pdf

                    }),

                    Task.Run(async () => {

                        folder = "books/gallery/";

                        //Se agregan todas las imagenes secundarias
                        foreach (var file in bookModel.GalleryFiles)
                        {

                            GalleryModel gallery = new()
                            {
                                Name = file.FileName,
                                Url = await UploadFile(folder, file)
                            };

                            bookModel.Gallery.Add(gallery);

                        }
                    })

                );

                await _bookService.AddBookAsync(bookModel); //Se agrega el libro.
            }

            return View();
        }

        private async Task<string> UploadFile(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
    }
}
