using Application.Abstractions;
using Application.Users.Commands.CreateUser;
using Domain.Abstractions;
using Domain.Entities;
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

namespace Application.Users.Commands.AuthenticateUser;

public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserCommand, string>
{
    private readonly IUserRepository _user;
    private readonly IJwtProwider _jwtProwider;

    public AuthenticateUserHandler(IUserRepository user, IJwtProwider jwtProwider)
    {
        _user = user;
        _jwtProwider = jwtProwider;
    }

    public async Task<string> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _user.GetByEmail(request.Email);
        if (user == null)
        {
            return String.Empty;
        }
        if (!VerifyPasswordHash(request.Password, user.Password, user.Salt))
        {
            return String.Empty;
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
