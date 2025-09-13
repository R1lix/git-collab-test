using BookStore.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAcces
{
    public class BookStoreDbContext  : DbContext

    {
        // Наш DB context с опциями
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) 
            : base(options)
        {

        }

        public DbSet<BookEntity> Books { get; set; }

    }
}
