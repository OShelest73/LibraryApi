using Application.Books.Commands.Create;
using Application.Books.Commands.DeleteBook;
using Application.Books.Commands.UpdateBook;
using Application.Books.Queries.GetAllBooks;
using Application.Books.Queries.GetBookById;
using Application.Books.Queries.GetBookByISBN;
using Application.Dtos.Book;
using Application.Users.Commands.AuthenticateUser;
using Application.Users.Commands.CreateUser;
using FluentValidation;
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
    private readonly IValidator<CreateBookCommand> _createValidator;
    private readonly IValidator<UpdateBookCommand> _updateValidator;

    public BookController(IMediator mediator, IValidator<CreateBookCommand> createValidator, IValidator<UpdateBookCommand> updateValidator)
    {
        _mediator = mediator;
        _createValidator = createValidator;
        _updateValidator = updateValidator;        
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

        var result = await _createValidator.ValidateAsync(command);

        if (!result.IsValid)
        {
            return BadRequest(result.ToDictionary());
        }

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

        var result = await _updateValidator.ValidateAsync(command);

        if (!result.IsValid)
        {
            return BadRequest(result.ToDictionary());
        }

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
