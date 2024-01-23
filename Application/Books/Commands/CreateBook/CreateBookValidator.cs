using Application.Books.Commands.Create;
using Domain.Abstractions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.CreateBook;

public sealed class CreateBookValidator: AbstractValidator<CreateBookCommand>
{
    public CreateBookValidator(IBookRepository book)
    {
        RuleFor(c => c.ISBN).MustAsync(async (ISBN, _) =>
        {
            return await book.IsISBNUniqueAsync(ISBN);
        }).WithMessage("The ISBN of the book must be unique");
        RuleFor(c => c.ISBN).MinimumLength(10).WithMessage("ISBN must contain at least 10 characters");
        RuleFor(c => c.Genre).MinimumLength(1).WithMessage("Genre must contain at least 1 character");
        RuleFor(c => c.Description).MinimumLength(1).WithMessage("Description must contain at least 1 character");
        RuleFor(c => c.Author).MinimumLength(1).WithMessage("Author must contain at least 1 character");
    }
}
