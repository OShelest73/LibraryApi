using Application.Users.Commands.CreateUser;
using Domain.Abstractions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.AuthenticateUser;

public sealed class AuthenticateUserValidator : AbstractValidator<AuthenticateUserCommand>
{
    public AuthenticateUserValidator()
    {
        RuleFor(c => c.AuthenticationRequest.Email).EmailAddress().WithMessage("Invalid email address");
        RuleFor(c => c.AuthenticationRequest.Password).NotEmpty().WithMessage("Password is required");
    }
}
