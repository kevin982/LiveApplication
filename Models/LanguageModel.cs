using BookStorePrueba.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorePrueba.Models
{
    public class LanguageModel : ICloneable
    {
        public int Id { get; set; } = 0;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public object Clone()
        {
            return new Language()
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description
            };
        }
    }
}
