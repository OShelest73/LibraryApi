using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Book
{
    int Id { get; set; }
    string ISBN { get; set; }
    string Genre { get; set; }
    string Description { get; set; }
    string Author { get; set; }
    DateTime BorrowingTime { get; set; }
    DateTime ReturnTime { get; set; }
}
