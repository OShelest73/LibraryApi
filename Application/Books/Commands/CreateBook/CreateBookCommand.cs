using Application.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.Create;

public sealed record CreateBookCommand(string ISBN, string Genre, string Description,
    string Author, DateTime BorrowingTime, DateTime ReturnTime) : IRequest;
