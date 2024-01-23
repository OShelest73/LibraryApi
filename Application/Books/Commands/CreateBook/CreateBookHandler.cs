using Application.Books.Commands.Create;
using Application.Dtos;
using AutoMapper;
using Domain.Abstractions;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.CreateBook;

public class CreateBookHandler: IRequestHandler<CreateBookCommand>
{
    private readonly IBookRepository _book;
    private readonly IValidator<CreateBookCommand> _createValidator;

    public CreateBookHandler(IBookRepository book, IValidator<CreateBookCommand> createValidator)
    {
        _book = book;
        _createValidator = createValidator;
    }

    public async Task Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _createValidator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        await _book.CreateBookAsync(request.ISBN, request.Genre, request.Description, 
            request.Author, request.BorrowingTime, request.ReturnTime);
    }
}
