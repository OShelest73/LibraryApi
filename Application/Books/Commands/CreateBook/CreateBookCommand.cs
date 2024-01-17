﻿using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.Create;

public sealed record CreateBookCommand(BookDto bookDto)
{
}
