﻿using Application.Books.Commands.Create;
using Application.Books.Queries.GetAllBooks;
using Application.CustomExceptions;
using Application.Dtos;
using Application.Dtos.User;
using Application.Users.Commands.AuthenticateUser;
using Application.Users.Commands.CreateUser;
using Application.Users.Queries.GetAllUsers;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LibraryApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<UserDto>> GetAllUsers(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetAllUsersQuery(), cancellationToken);
    }

    [HttpPost]
    public async Task<ActionResult> Register([FromBody] RegisterDto registerDto, CancellationToken cancellationToken)
    {
        var command = new CreateUserCommand(registerDto);

        try
        {
            await _mediator.Send(command, cancellationToken);
        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors.Select(error => new { error.PropertyName, error.ErrorMessage });
            return BadRequest(errors);
        }

        return Ok();
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] AuthenticationRequest authenticationRequest, CancellationToken cancellationToken)
    {
        var command = new AuthenticateUserCommand(authenticationRequest);

        try
        {
            string token = await _mediator.Send(command, cancellationToken);

            return Ok(token);
        }
        catch (ValidationException validationEx)
        {
            var errors = validationEx.Errors.Select(error => new { error.PropertyName, error.ErrorMessage });
            return BadRequest(errors);
        }
        catch (InvalidCredentialsException credentialsEx)
        {
            return Unauthorized(credentialsEx.Message);
        }
    }
}
