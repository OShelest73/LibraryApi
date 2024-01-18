using Application.Books.Commands.Create;
using Domain.Abstractions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IUserRepository _user;

    public CreateUserHandler(IUserRepository user)
    {
        _user = user;
    }

    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        string securePassword = CreatePasswordHash(request.Password, out byte[] passwordSalt);

        await _user.CreateUser(request.FullName, request.Email, securePassword, passwordSalt);
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
