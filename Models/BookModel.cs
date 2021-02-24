using BookStorePrueba.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorePrueba.Models
{
    public class BookModel : ICloneable
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Tiene que llenar la descripcion."), MaxLength(50)]
        public string Description { get; set; }

        [Required, Range(100, 1000)]
        public int Pages { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        [Required, MaxLength(50), MinLength(3)]
        public string Title { get; set; }

        [Required, MaxLength(50), MinLength(5)]
        public string Author { get; set; }

        [Required(ErrorMessage = "You must fill the language")]
        public int Language { get; set; }

        public string LanguageName { get; set; } = string.Empty;


        [Required]
        public string Category { get; set; }

        [Display(Name = "Choose the cover image to your book")]
        [Required]
        public IFormFile Image { get; set; }

        public string CoverImageUrl { get; set; } = string.Empty;

        [Display(Name = "Choose the gallery images of your book")]
        [Required]

        public IFormFileCollection GalleryFiles { get; set; }


        public List<GalleryModel> Gallery { get; set; } = new();


        [Required]
        [Display(Name = "Upload the book in pdf format")]
        public IFormFile BookPdf { get; set; }

        public string BookPdfUrl { get; set; }


        public object Clone()
        {

            List<Gallery> images = new();

            foreach (var item in Gallery)
            {
                images.Add((Gallery)item.Clone());
            }


            return new Book()
            {
                Id = this.Id,
                Pages = this.Pages,
                Title = this.Title,
                Author = this.Author,
                Description = this.Description,
                LanguageId = this.Language,
                Category = this.Category,
                CoverImageUrl = this.CoverImageUrl,
                Images = images,
                PdfUrl = this.BookPdfUrl
            };
        }
    }
}
