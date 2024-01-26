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

    public async Task CreateBookAsync(Book book, CancellationToken cancellationToken)
    {
        await _dbContext.Books.AddAsync(book);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateBookAsync(Book book, CancellationToken cancellationToken)
    {
        _dbContext.Update(book);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteBookAsync(Book book, CancellationToken cancellationToken)
    {
        _dbContext.Remove(book);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> IsBookExistAsync(int id)
    {
        return await _dbContext.Books.AnyAsync(b => b.Id == id);
    }

    public async Task<bool> IsISBNUniqueAsync(string ISBN)
    {
        return !await _dbContext.Books.AnyAsync(b => b.Isbn == ISBN);
    }
}
