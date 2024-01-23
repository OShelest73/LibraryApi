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
    Task CreateBookAsync(Book book, CancellationToken cancellationToken);
    Task UpdateBookAsync(Book book, CancellationToken cancellationToken);
    Task DeleteBookAsync(Book book, CancellationToken cancellationToken);
    Task<bool> IsISBNUniqueAsync(string ISBN);
}
