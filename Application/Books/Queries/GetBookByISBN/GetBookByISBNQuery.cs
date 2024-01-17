using Application.Dtos.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Queries.GetBookByISBN;

public sealed record GetBookByISBNQuery(string ISBN) : IRequest<BookDto>;
