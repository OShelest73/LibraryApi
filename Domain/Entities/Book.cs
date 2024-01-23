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
    public Genre Genre { get; set; }
    public string Description { get; set; } = string.Empty;
    public Author Author { get; set; }
    public DateTime BorrowingTime { get; set; }
    public DateTime ReturnTime { get; set; }

    //public Book(int id, string isbn, Genre genre, string description, Author author, DateTime borrowingTime, DateTime returnTime)
    //{
    //    Id = id;
    //    Isbn = isbn;
    //    Genre = genre;
    //    Description = description;
    //    Author = author;
    //    BorrowingTime = borrowingTime;
    //    ReturnTime = returnTime;
    //}

    //public Book(string isbn, Genre genre, string description, Author author, DateTime borrowingTime, DateTime returnTime)
    //{
    //    Isbn = isbn;
    //    Genre = genre;
    //    Description = description;
    //    Author = author;
    //    BorrowingTime = borrowingTime;
    //    ReturnTime = returnTime;
    //}
}
