using Application.Books.Commands.Create;
using Application.Books.Commands.DeleteBook;
using Application.Books.Commands.UpdateBook;
using Application.Books.Queries.GetAllBooks;
using Application.Books.Queries.GetBookById;
using Application.Books.Queries.GetBookByISBN;
using Application.Dtos.Book;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibraryApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BookController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<BookDto>> GetAllBooks()
    {
        return await _mediator.Send(new GetAllBooksQuery());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BookDto>> GetBookById(int id)
    {
        return await _mediator.Send(new GetBookByIdQuery(id));
    }

    [HttpGet("isbn/{isbn}")]
    public async Task<ActionResult<BookDto>> GetBookByISBN(string isbn)
    {
        return await _mediator.Send(new GetBookByISBNQuery(isbn));
    }

    [HttpPost]
    public async Task<ActionResult> CreateBook(CreateBookDto book)
    {
        var command = new CreateBookCommand(
            book.ISBN,
            book.Genre,
            book.Description,
            book.Author,
            book.BorrowingTime,
            book.ReturnTime);
        await _mediator.Send(command);

        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateBook(BookDto book)
    {
        var command = new UpdateBookCommand(
            book.Id,
            book.ISBN,
            book.Genre,
            book.Description,
            book.Author,
            book.BorrowingTime,
            book.ReturnTime);
        await _mediator.Send(command);

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteBookById(int id)
    {
        await _mediator.Send(new DeleteBookCommand(id));

        return Ok();
    }

}
