using Application.Books.Commands.Create;
using Application.Dtos;
using AutoMapper;
using Domain.Abstractions;
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

    public CreateBookHandler(IBookRepository book)
    {
        _book = book;
    }

    public async Task Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        await _book.CreateBook(request.ISBN, request.Genre, request.Description, 
            request.Author, request.BorrowingTime, request.ReturnTime);
    }
}
