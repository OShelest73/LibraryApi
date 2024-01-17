using Application.Books.Queries.GetAllBooks;
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

namespace Application.Books.Queries.GetBookById;

public class GetBookByIdHandler: IRequestHandler<GetBookByIdQuery, BookDto>
{
    private readonly IBookRepository _book;
    private readonly IMapper _mapper;

    public GetBookByIdHandler(IBookRepository book, IMapper mapper)
    {
        _book = book;
        _mapper = mapper;
    }

    public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await _book.GetBookById(request.Id);
        //mapper for mapper's sake
        var booksDto = _mapper.Map<Book, BookDto>(book);

        return booksDto;
    }
}
