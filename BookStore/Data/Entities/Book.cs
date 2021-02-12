using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data.Entities
{
    public class Book
    {
        public int Id { get; set; } = 0;

        public int Pages { get; set; } = 0;

        public DateTime CreatedOn { get; set; }

        public DateTime UpddatedOn { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Language { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;
    }
}
