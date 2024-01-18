using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Book
{
    public int Id { get; set; }
    public string Isbn { get; set; } = string.Empty;
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

    public Book(int id, string isbn, string genre, string description, string author, DateTime borrowingTime, DateTime returnTime)
    {
        Id = id;
        Isbn = isbn;
        Genre = genre;
        Description = description;
        Author = author;
        BorrowingTime = borrowingTime;
        ReturnTime = returnTime;
    }

    public Book(string isbn, string genre, string description, string author, DateTime borrowingTime, DateTime returnTime)
    {
        Isbn = isbn;
        Genre = genre;
        Description = description;
        Author = author;
        BorrowingTime = borrowingTime;
        ReturnTime = returnTime;
    }
}
