using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Book
{
    public int Id { get; set; }
    public string ISBN { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;

    //Getter and setter сonversions if we consider different timezones
    public DateTime BorrowingTime
    {
        get { return BorrowingTime.ToLocalTime(); } 
        set { BorrowingTime = value.ToUniversalTime(); }
    }

    //Getter and setter сonversions if we consider different timezones
    public DateTime ReturnTime
    {
        get { return ReturnTime.ToLocalTime(); }
        set { ReturnTime = value.ToUniversalTime(); }
    }
}
