using BookStore.Application.Services;
using BookStore.Contracts;
using BookStore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;
        public BooksController (IBooksService booksService)
        {
            _booksService = booksService;
        }
        //это что за метод, артем
        //это что за метод, артем
        [HttpGet]
        public async Task<ActionResult<List<BooksResponse>>> GetBooks()
        {
            var books = await _booksService.GetAllBooks();

            var response = books.Select(b => new BooksResponse(b.id, b.title, b.description, b.price));

            return Ok(response);
        }
        //это что за метод, артем
        //это что за метод, артем
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateBook([FromBody] BooksRequest request)
        {
            var (book, error) = Book.Create(
                Guid.NewGuid(),
                request.title,
                request.decription,
                request.price);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var bookId = await _booksService.CreateBook(book);

            return Ok(bookId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateBook(Guid id, [FromBody] BooksRequest request)
        {
            var bookId = await _booksService.UpdateBook(id, request.title, request.decription, request.price);  

            return(bookId);
        }
        //это что за метод, артем

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteBook(Guid id)
        {
            return Ok(await _booksService.DeleteBook(id));
        }

        //тестовый метод сучка
        public async Task<ActionResult> TestMethod()
        {
            var error = "ошибка доступа баляяя";
            return Forbid(error);
        }
    }
}
