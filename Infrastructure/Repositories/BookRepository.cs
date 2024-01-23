using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _dbContext;

    public BookRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Book>> GetAllBooksAsync(CancellationToken cancellationToken)
    {
        var result = await _dbContext.Books.AsNoTracking().ToListAsync(cancellationToken);
        return result;
    }

    public async Task<Book> GetBookByIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _dbContext.Books.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
        return result;
    }

    public async Task<Book> GetBookByISBNAsync(string ISBN, CancellationToken cancellationToken)
    {
        var result = await _dbContext.Books.AsNoTracking().FirstOrDefaultAsync(b => b.Isbn == ISBN, cancellationToken);
        return result;
    }

    public async Task CreateBookAsync(string isbn, string genre, string description, string author, DateTime borrowingTime, DateTime returnTime, CancellationToken cancellationToken)
    {
        var book = new Book(isbn, genre, description, author, borrowingTime, returnTime);
        await _dbContext.Books.AddAsync(book);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateBookAsync(int id, string isbn, string genre, string description, string author, DateTime borrowingTime, DateTime returnTime, CancellationToken cancellationToken)
    {
        var book = new Book(id, isbn, genre, description, author, borrowingTime, returnTime);
        _dbContext.Update(book);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteBookAsync(int id, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
        if (user != null)
        {
            _dbContext.Remove(user);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task<bool> IsISBNUniqueAsync(string ISBN)
    {
        return !await _dbContext.Books.AnyAsync(b => b.Isbn == ISBN);
    }
}
