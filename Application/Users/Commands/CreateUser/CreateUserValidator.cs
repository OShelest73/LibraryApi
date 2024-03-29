﻿using Application.Books.Commands.Create;
using Domain.Abstractions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser;

public sealed class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator(IUserRepository user)
    {
        RuleFor(c => c.RegisterDto.Email).EmailAddress().MustAsync(async (Email, _) =>
        {
            return await user.IsEmailUniqueAsync(Email);
        }).WithMessage("Invalid email address");
        RuleFor(c => c.RegisterDto.FullName).MinimumLength(8).WithMessage("Full name must contain at least 8 characters");
        RuleFor(c => c.RegisterDto.Password).MinimumLength(6).WithMessage("Password must contain at least 6 character");
    }
}
