using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos;

public class CreateBookDto
{
    string ISBN { get; set; }
    string Genre { get; set; }
    string Description { get; set; }
    string Author { get; set; }
    DateTime BorrowingTime { get; set; }
    DateTime ReturnTime { get; set; }
}
