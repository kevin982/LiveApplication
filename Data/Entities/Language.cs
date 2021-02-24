using BookStorePrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorePrueba.Data.Entities
{
    public class Language : ICloneable
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public List<Book> Books { get; set; }

        public object Clone()
        {
            return new LanguageModel()
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description
            };
        }
    }
}
