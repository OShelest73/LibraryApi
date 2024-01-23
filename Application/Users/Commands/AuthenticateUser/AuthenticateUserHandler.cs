using Application.Abstractions;
using Application.CustomExceptions;
using Application.Users.Commands.CreateUser;
using Domain.Abstractions;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Users.Commands.AuthenticateUser;

public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserCommand, string>
{
    private readonly IUserRepository _user;
    private readonly IJwtProwider _jwtProwider;
    private readonly IValidator<AuthenticateUserCommand> _authenticateValidator;

    public AuthenticateUserHandler(IUserRepository user, IJwtProwider jwtProwider, IValidator<AuthenticateUserCommand> authenticateValidator)
    {
        _user = user;
        _jwtProwider = jwtProwider;
        _authenticateValidator = authenticateValidator;
    }

    public async Task<string> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _authenticateValidator.ValidateAsync(request);

        if(!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var user = await _user.GetByEmailAsync(request.Email);
        if (user == null)
        {
            throw new InvalidCredentialsException();
        }
        if (!VerifyPasswordHash(request.Password, user.Password, user.Salt))
        {
            throw new InvalidCredentialsException();
        }

        var token = _jwtProwider.Generate(user);

        return token;
    }

    private bool VerifyPasswordHash(string password, string passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            var translatedHash = Encoding.UTF8.GetString(computedHash);

            return translatedHash.Equals(passwordHash);
        }
    }
}
