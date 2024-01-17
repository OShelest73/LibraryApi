using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.UpdateBook;

public sealed record UpdateBookCommand(int Id, string ISBN, string Genre, string Description,
    string Author, DateTime BorrowingTime, DateTime ReturnTime) : IRequest;
