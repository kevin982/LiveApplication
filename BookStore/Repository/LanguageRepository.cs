using BookStore.Data;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class LanguageRepository
    {
        private readonly BookStoreContext context = null;

        public LanguageRepository(BookStoreContext _context)
        {
            context = _context;
        }

        public async Task<List<LanguageModel>> GetAllLanguages()
        {
            return await context.Languages.Select(x => new LanguageModel()
            {

                Id = x.Id,
                Name = x.Name,
                Description = x.Description

            }).ToListAsync();
        }

    }
}
