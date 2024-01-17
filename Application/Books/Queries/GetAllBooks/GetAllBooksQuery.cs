using Application.Dtos.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Queries.GetAllBooks;

public sealed record GetAllBooksQuery(): IRequest<List<BookDto>>;

