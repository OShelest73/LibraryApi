using Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibraryApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<>> GetAllBooks()
    {
        
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
    public async Task<ActionResult> CreateBook(BookDto book)
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
