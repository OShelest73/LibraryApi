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
    public string Genre { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public DateTime BorrowingTime { get; set; }
    public DateTime ReturnTime { get; set; }
}
