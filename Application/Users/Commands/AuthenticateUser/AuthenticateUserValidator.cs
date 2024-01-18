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
        RuleFor(c => c.Email).EmailAddress().WithMessage("Invalid email address");
        RuleFor(c => c.Password).NotEmpty().WithMessage("Password is required");
    }
}
