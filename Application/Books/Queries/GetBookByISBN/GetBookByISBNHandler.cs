using Application.Books.Queries.GetBookById;
using Application.CustomExceptions;
using Application.Dtos.Book;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Queries.GetBookByISBN;

public class GetBookByISBNHandler : IRequestHandler<GetBookByISBNQuery, BookDto>
{
    private readonly IBookRepository _book;
    private readonly IMapper _mapper;

    public GetBookByISBNHandler(IBookRepository book, IMapper mapper)
    {
        _book = book;
        _mapper = mapper;
    }

    public async Task<BookDto> Handle(GetBookByISBNQuery request, CancellationToken cancellationToken)
    {
        var book = await _book.GetBookByISBNAsync(request.ISBN, cancellationToken);

        if (book == null)
        {
            throw new BookNotFoundException();
        }

        //mapper for mapper's sake
        var booksDto = _mapper.Map<Book, BookDto>(book);

        return booksDto;
    }
}
