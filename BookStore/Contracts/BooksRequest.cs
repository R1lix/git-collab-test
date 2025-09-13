namespace BookStore.Contracts
{
    public record BooksRequest(
        Guid id,
        string title,
        string decription,
        decimal price);
}
