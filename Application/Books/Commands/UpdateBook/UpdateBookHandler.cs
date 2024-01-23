using Application.Books.Commands.Create;
using AutoMapper;
using Domain.Abstractions;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.UpdateBook;

public class UpdateBookHandler : IRequestHandler<UpdateBookCommand>
{
    private readonly IBookRepository _book;
    private readonly IValidator<UpdateBookCommand> _updateValidator;

    public UpdateBookHandler(IBookRepository book, IValidator<UpdateBookCommand> updateValidator)
    {
        _book = book;
        _updateValidator = updateValidator;
    }

    public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _updateValidator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        await _book.UpdateBookAsync(request.Id ,request.ISBN, request.Genre, request.Description,
            request.Author, request.BorrowingTime, request.ReturnTime, cancellationToken);
    }
}
