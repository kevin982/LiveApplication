using BookStorePrueba.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorePrueba.Models
{
    public class GalleryModel : ICloneable
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;

        public object Clone()
        {
            return new Gallery()
            {
                Id = this.Id,
                Name = this.Name,
                Url = this.Url
            };
        }
    }
}
