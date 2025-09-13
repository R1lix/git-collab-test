namespace BookStore.Contracts
{
    public record BooksResponse (
        Guid id, 
        string title, 
        string decription, 
        decimal price);


}
