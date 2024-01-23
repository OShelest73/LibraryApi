using Application.Books.Commands.Create;
using Domain.Abstractions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.UpdateBook;

public sealed class UpdateBookValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookValidator()
    {
        RuleFor(c => c.BookDto.Id).NotEmpty();
        RuleFor(c => c.BookDto.ISBN).MinimumLength(10).WithMessage("ISBN must contain at least 10 characters");
        RuleFor(c => c.BookDto.Genre.GenreName).MinimumLength(1).WithMessage("Genre name must contain at least 1 character");
        RuleFor(c => c.BookDto.Description).MinimumLength(1).WithMessage("Description must contain at least 1 character");
        RuleFor(c => c.BookDto.Author.FirstName).MinimumLength(1).WithMessage("Author's first name must contain at least 1 character");
        RuleFor(c => c.BookDto.Author.LastName).MinimumLength(1).WithMessage("Author's last name must contain at least 1 character");
    }
}
