using BookStorePrueba.Data.Entities;
using BookStorePrueba.Models.Tables;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorePrueba.Data.Context
{
    public class BookStoreContext : IdentityDbContext<UserTable>
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        public DbSet<Language> Languages { get; set; }

    }
}
