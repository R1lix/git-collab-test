using BookStore.Core.Models;
using BookStore.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAcces.Reposotories
{
    public class BookRepository : IBooksRepository
    {
        private readonly BookStoreDbContext _context;
        public BookRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> Get()
        {
            var bookEntites = await _context.Books
                .AsNoTracking()
                .ToListAsync();

            var books = bookEntites
                .Select(b => Book.Create(b.id, b.title, b.description, b.price).Book)
                .ToList();

            return books;
        }

        public async Task<Guid> Create(Book book)
        {
            var bookEntity = new BookEntity
            {
                id = book.id,
                title = book.title,
                description = book.description,
                price = book.price,
            };

            await _context.Books.AddAsync(bookEntity);
            await _context.SaveChangesAsync();

            return bookEntity.id;
        }

        public async Task<Guid> Update(Guid id, string title, string description, decimal price)
        {
            await _context.Books
                .Where(b => b.id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.title, b => title)
                .SetProperty(b => b.description, b => description)
                .SetProperty(b => b.price, b => price));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Books
                .Where(b => b.id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
