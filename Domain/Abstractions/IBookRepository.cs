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
    Task CreateBook(Book book);
    Task UpdateBook(Book book);
    Task DeleteBook(int id);
}
