using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions;

public interface IBookRepository
{
    Task<List<Book>> GetAllBooksAsync(CancellationToken cancellationToken);
    Task<Book> GetBookByIdAsync(int id, CancellationToken cancellationToken);
    Task<Book> GetBookByISBNAsync(string ISBN, CancellationToken cancellationToken);
    Task CreateBookAsync(string isbn, string genre, string description, string author, DateTime borrowingTime, DateTime returnTime, CancellationToken cancellationToken);
    Task UpdateBookAsync(int id, string isbn, string genre, string description, string author, DateTime borrowingTime, DateTime returnTime, CancellationToken cancellationToken);
    Task DeleteBookAsync(int id, CancellationToken cancellationToken);
    Task<bool> IsISBNUniqueAsync(string ISBN);
}
