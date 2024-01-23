using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions;

public interface IBookRepository
{
    Task<List<Book>> GetAllBooksAsync();
    Task<Book> GetBookByIdAsync(int id);
    Task<Book> GetBookByISBNAsync(string ISBN);
    Task CreateBookAsync(string isbn, string genre, string description, string author, DateTime borrowingTime, DateTime returnTime);
    Task UpdateBookAsync(int id, string isbn, string genre, string description, string author, DateTime borrowingTime, DateTime returnTime);
    Task DeleteBookAsync(int id);
    Task<bool> IsISBNUniqueAsync(string ISBN);
}
