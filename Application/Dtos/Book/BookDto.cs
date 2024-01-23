﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Book;

public class BookDto
{
    public int Id { get; set; }
    public string ISBN { get; set; }
    public Genre Genre { get; set; }
    public string Description { get; set; }
    public Author Author { get; set; }
    public DateTime BorrowingTime { get; set; }
    public DateTime ReturnTime { get; set; }
}
