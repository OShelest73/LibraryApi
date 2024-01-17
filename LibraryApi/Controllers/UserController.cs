using Application.Books.Commands.Create;
using Application.Books.Queries.GetAllBooks;
using Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpGet]
    public async Task<List<>> GetAllUsers()
    {
        
    }

    [HttpPost]
    public async Task<ActionResult> Register()
    {
        //return Ok();
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] )
    {

    }
}
