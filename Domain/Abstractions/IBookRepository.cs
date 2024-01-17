using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions;

public interface IBookRepository
{
    Task<List<Book>> GetAllBooks();
    Task<Book> GetBookById(int id);
    Task<Book> GetBookByISBN(string ISBN);
    Task CreateBook(string isbn, string genre, string description, string author, DateTime borrowingTime, DateTime returnTime);
    Task UpdateBook(int id, string isbn, string genre, string description, string author, DateTime borrowingTime, DateTime returnTime);
    Task DeleteBook(int id);
    Task<bool> IsISBNUnique(string ISBN);
}
