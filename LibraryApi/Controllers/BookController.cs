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

    public BookController(IMediator mediator)
    {
        _mediator = mediator;        
    }

    [HttpGet]
    public async Task<List<BookDto>> GetAllBooks(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetAllBooksQuery());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BookDto>> GetBookById(int id, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetBookByIdQuery(id));
    }

    [HttpGet("isbn/{isbn}")]
    public async Task<ActionResult<BookDto>> GetBookByISBN(string isbn, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetBookByISBNQuery(isbn));
    }

    [HttpPost]
    public async Task<ActionResult> CreateBook([FromBody] CreateBookDto book, CancellationToken cancellationToken)
    {
        var command = new CreateBookCommand(book);

        try
        {
            await _mediator.Send(command);
        }
        catch(ValidationException ex) 
        {
            var errors = ex.Errors.Select(error => new { error.PropertyName, error.ErrorMessage });
            return BadRequest(errors);
        }        

        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateBook(BookDto book, CancellationToken cancellationToken)
    {
        var command = new UpdateBookCommand(book);

        try
        {
            await _mediator.Send(command);
        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors.Select(error => new { error.PropertyName, error.ErrorMessage });
            return BadRequest(errors);
        }

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteBookById(int id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteBookCommand(id));

        return Ok();
    }

}
