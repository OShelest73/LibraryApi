using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomExceptions;

public class BookNotFoundException: Exception
{
    public BookNotFoundException(): base("Error processing request. Book wasn't found")
    {
        
    }
}
