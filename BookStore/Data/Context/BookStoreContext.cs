using Microsoft.EntityFrameworkCore;
using BookStore.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BookStore.Data
{
    public class BookStoreContext: IdentityDbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options):base(options){}
        
        public DbSet<Book> Books { get; set; }

        public DbSet<Language> Languages { get; set; }

    }
}
