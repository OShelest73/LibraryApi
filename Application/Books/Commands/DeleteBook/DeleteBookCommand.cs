using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.DeleteBook;

public sealed record DeleteBookCommand(int Id) : IRequest;
