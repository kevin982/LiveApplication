using System;
using System.ComponentModel.DataAnnotations;


namespace BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        
        
        [Required(ErrorMessage = "Tiene que llenar la descripcion."), MaxLength(20)]
        public string Description { get; set; }
        
        [Required, Range(100,1000)]
        public int Pages{ get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        [Required, MaxLength(20), MinLength(3)]
        public string Title { get; set; }

        [Required, MaxLength(20), MinLength(5)]
        public string Author { get; set; }

        [Required(ErrorMessage ="You must fill the language")]
        public string Language{ get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public string MyField { get; set; }

    }
}
