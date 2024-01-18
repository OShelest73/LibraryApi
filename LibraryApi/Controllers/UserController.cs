﻿using Application.Books.Commands.Create;
using Application.Books.Queries.GetAllBooks;
using Application.Dtos;
using Application.Dtos.User;
using Application.Users.Commands.AuthenticateUser;
using Application.Users.Commands.CreateUser;
using Application.Users.Queries.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LibraryApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<List<UserDto>> GetAllUsers()
    {
        return await _mediator.Send(new GetAllUsersQuery());
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var command = new CreateUserCommand(registerDto.FullName, registerDto.Email, registerDto.Password);

        await _mediator.Send(command);

        return Ok();
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] AuthenticationRequest authenticationRequest)
    {
        var command = new AuthenticateUserCommand(authenticationRequest.Email, authenticationRequest.Password);

        string token = await _mediator.Send(command);

        if (token.IsNullOrEmpty())
        {
            return Unauthorized("Invalid login or password");
        }

        return Ok(token);
    }
}