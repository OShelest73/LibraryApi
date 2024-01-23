﻿using Application.Books.Commands.Create;
using Application.Dtos;
using Application.Dtos.Book;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entities;
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
    private readonly IMapper _mapper;
    private readonly IValidator<CreateBookCommand> _createValidator;

    public CreateBookHandler(IBookRepository book, IMapper mapper, IValidator<CreateBookCommand> createValidator)
    {
        _book = book;
        _mapper = mapper;
        _createValidator = createValidator;
    }

    public async Task Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _createValidator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var book = _mapper.Map<Book>(request.BookDto);

        await _book.CreateBookAsync(book, cancellationToken);
    }
}
