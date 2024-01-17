using Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Queries.GetAllBooks;

public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, List<BookDto>>
{
    public Task<List<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
