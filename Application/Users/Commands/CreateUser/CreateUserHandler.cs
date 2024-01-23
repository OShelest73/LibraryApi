﻿using Application.Books.Commands.Create;
using Domain.Abstractions;
using Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Users.Commands.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IUserRepository _user;
    private readonly IValidator<CreateUserCommand> _createValidator;

    public CreateUserHandler(IUserRepository user, IValidator<CreateUserCommand> createValidator)
    {
        _user = user;
        _createValidator = createValidator;
    }

    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _createValidator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        string securePassword = CreatePasswordHash(request.Password, out byte[] passwordSalt);

        await _user.CreateUserAsync(request.FullName, request.Email, securePassword, passwordSalt);
    }

    private string CreatePasswordHash(string password, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            password = Encoding.UTF8.GetString(passwordHash);

            return password;
        }
    }
}
