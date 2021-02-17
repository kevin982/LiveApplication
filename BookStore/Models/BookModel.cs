using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;


namespace BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        
        
        [Required(ErrorMessage = "Tiene que llenar la descripcion."), MaxLength(50)]
        public string Description { get; set; }
        
        [Required, Range(100,1000)]
        public int Pages{ get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        [Required, MaxLength(50), MinLength(3)]
        public string Title { get; set; }

        [Required, MaxLength(50), MinLength(5)]
        public string Author { get; set; }

        [Required(ErrorMessage ="You must fill the language")]
        public int Language{ get; set; }

        public string LanguageName { get; set; } = string.Empty;


        [Required]
        public string Category { get; set; }
 
        [Required]
        public IFormFile Image{ get; set; }

        public string ImageUrl { get; set; } = string.Empty;

    }
}
