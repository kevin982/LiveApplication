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
        public async Task<ViewResult> GetAllBooksAsync()
        {

            var data = await _bookRepository.GetAllBookAsync();

            return View(data);
        }

        public async Task<ViewResult> GetBookAsync(int id)
        {
            var data= await _bookRepository.GetBookByIdAsync(id);
            return View(data);
        }

        public async Task<ViewResult> AddNewBookAsync()
        {
            ViewBag.Languages = await _languageRepository.GetAllLanguagesAsync();

            return View();
        }

        [HttpPost]
        public async Task<ViewResult> AddNewBookAsync(BookModel bookModel)
        {

            ViewBag.Languages = await _languageRepository.GetAllLanguagesAsync();
            string folder = "";


            if (ModelState.IsValid)
            {

                Task.WaitAll(

                    Task.Run(async ()=>{ 

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
 
                await _bookRepository.AddBookAsync(bookModel); //Se agrega el libro.
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
