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

    public async Task<List<Book>> GetAllBooks()
    {
        var result = await _dbContext.Books.ToListAsync();
        return result;
    }

    public async Task<Book> GetBookById(int id)
    {
        var result = await _dbContext.Books.FindAsync(id);
        return result;
    }

    public async Task<Book> GetBookByISBN(string ISBN)
    {
        var result = await _dbContext.Books.FirstOrDefaultAsync(b => b.ISBN == ISBN);
        return result;
    }

    public async Task CreateBook(string isbn, string genre, string description, string author, DateTime borrowingTime, DateTime returnTime)
    {
        var book = new Book(isbn, genre, description, author, borrowingTime, returnTime);
        await _dbContext.Books.AddAsync(book);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateBook(int id, string isbn, string genre, string description, string author, DateTime borrowingTime, DateTime returnTime)
    {
        var book = new Book(id, isbn, genre, description, author, borrowingTime, returnTime);
        _dbContext.Update(book);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteBook(int id)
    {
        var user = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
        if (user != null)
        {
            _dbContext.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<bool> IsISBNUnique(string ISBN)
    {
        return !await _dbContext.Books.AnyAsync(b => b.ISBN == ISBN);
    }
}
