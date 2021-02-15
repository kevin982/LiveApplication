using Microsoft.EntityFrameworkCore;
using BookStore.Data.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class BookStoreContext:DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options):base(options){}
        
        public DbSet<Book> Books { get; set; }

        public DbSet<Language> Languages { get; set; }

    }
}
