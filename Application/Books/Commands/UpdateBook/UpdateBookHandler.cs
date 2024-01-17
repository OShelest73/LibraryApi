using Application.Books.Commands.Create;
using AutoMapper;
using Domain.Abstractions;
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

    public UpdateBookHandler(IBookRepository book)
    {
        _book = book;
    }

    public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        await _book.UpdateBook(request.Id ,request.ISBN, request.Genre, request.Description,
            request.Author, request.BorrowingTime, request.ReturnTime);
    }
}
