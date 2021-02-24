using BookStorePrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorePrueba.Data.Entities
{
    public class Gallery : ICloneable
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;

        public Book Book { get; set; }

        public int BookId { get; set; }

        public object Clone()
        {
            return new GalleryModel()
            {
                Id = this.Id,
                Name = this.Name,
                Url = this.Url
            };
        }
    }
}
