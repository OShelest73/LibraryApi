using Application.Books.Queries.GetAllBooks;
using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibraryApi.Controllers;

[Route("api/[controller]")]
[ApiController]
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
    public async Task<ActionResult<>> GetBookById(int id)
    {
        
    }

    [HttpGet("isbn/{isbn}")]
    public async Task<ActionResult<>> GetBookByISBN(string isbn)
    {
        
    }

    [HttpPost]
    public async Task<ActionResult> CreateBook(CreateBookDto book)
    {
        
    }

    [HttpPut]
    public async Task<ActionResult> UpdateBook(BookDto book)
    {
        
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteBookById(int id)
    {
        
    }

}
