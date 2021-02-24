using BookStorePrueba.Data.Context;
using BookStorePrueba.Models;
using BookStorePrueba.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorePrueba.Services.Classes
{
    public class LanguageService : ILanguageService
    {
        private readonly BookStoreContext context = null;

        public LanguageService(BookStoreContext _context)
        {
            context = _context;
        }

        public async Task<List<LanguageModel>> GetAllLanguagesAsync()
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
