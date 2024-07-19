using LibraLoan.Application.Commands.CreateBook;
using LibraLoan.Application.Commands.DeleteBook;
using LibraLoan.Application.Commands.LoanBook;
using LibraLoan.Application.Commands.ReceiveBook;
using LibraLoan.Application.Queries.GetAllBooks;
using LibraLoan.Application.Queries.GetBookById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraLoan.API.Controllers
{
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "client, employee")]
        public async Task<IActionResult> Get(string query)
        {
            var getAllBooksQuery = new GetAllBooksQuery(query);

            var books = await _mediator.Send(getAllBooksQuery);

            return Ok(books);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "client, employee")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetBookByIdQuery(id);

            var book = await _mediator.Send(query);

            if (book == null) return NotFound();

            return Ok(book);
        }

        [HttpPost]
        [Authorize(Roles = "employee")]
        public async Task<IActionResult> RegisterBook([FromBody] CreateBookCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "employee")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var command = new DeleteBookCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("/registerloan")]
        [Authorize(Roles = "client, employee")]
        public async Task<IActionResult> RegisterLoan([FromBody] LoanBookCommand command)
        {
            var loan = new LoanBookCommand(command.BookId, command.UserId);

            await _mediator.Send(loan);

            return NoContent();
        }

        [HttpPut("{id}/receivebook")]
        [Authorize(Roles = "employee")]
        public async Task<IActionResult> ReceiveBook(int id)
        {
            var command = new ReceiveBookCommand(id);

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
