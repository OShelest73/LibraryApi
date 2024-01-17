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

namespace Application.Books.Queries.GetAllBooks;

public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, List<BookDto>>
{
    private readonly IBookRepository _book;
    private readonly IMapper _mapper;

    public GetAllBooksHandler(IBookRepository book, IMapper mapper)
    {
        _book = book;
        _mapper = mapper;
    }

    public async Task<List<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _book.GetAllBooks();
        //mapper for mapper's sake
        var booksDto = _mapper.Map<List<Book>,List<BookDto>>(books);

        return booksDto;
    }
}
