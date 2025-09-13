using BookStore.Core.Models;

namespace BookStore.DataAcces.Reposotories
{
    public interface IBooksRepository
    {
        Task<Guid> Create(Book book);
        Task<Guid> Update(Guid id, string title, string description, decimal price);
        Task<Guid> Delete(Guid id);
        Task<List<Book>> Get();
    }
}