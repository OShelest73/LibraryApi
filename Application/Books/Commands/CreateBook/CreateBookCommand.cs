using Application.Dtos;
using Application.Dtos.Book;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.Create;

public sealed record CreateBookCommand(CreateBookDto BookDto) : IRequest;
