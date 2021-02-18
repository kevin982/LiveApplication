using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data.Entities
{
    public class Book:ICloneable
    {
        public int Id { get; set; } = 0;

        public int Pages { get; set; } = 0;

        public DateTime CreatedOn { get; set; }

        public DateTime UpddatedOn { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int LanguageId { get; set; }

        public Language Language { get; set; }

        public string Category { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public List<Gallery> Images { get; set; }

        public object Clone()
        {

            List<GalleryModel> gallery = new();

            foreach (var item in Images)
            {
                gallery.Add((GalleryModel)item.Clone());
            }

            return new BookModel()
            { 
                Id = this.Id,
                Description = this.Description,
                Pages = this.Pages,
                Title = this.Title,
                Author = this.Author,
                Language = this.Language.Id,
                LanguageName = this.Language.Name,
                Category = this.Category,
                ImageUrl = this.ImageUrl,
                Gallery = gallery            
            };
 
        }
    }
}
