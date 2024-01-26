using Application.Books.Commands.Create;
using Application.CustomExceptions;
using Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.DeleteBook;

public class DeleteBookHandler : IRequestHandler<DeleteBookCommand>
{
    private readonly IBookRepository _book;

    public DeleteBookHandler(IBookRepository book)
    {
        _book = book;
    }

    public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _book.GetBookByIdAsync(request.Id, cancellationToken);

        if (book == null)
        {
            throw new BookNotFoundException();
        }

        await _book.DeleteBookAsync(book, cancellationToken);
    }
}
