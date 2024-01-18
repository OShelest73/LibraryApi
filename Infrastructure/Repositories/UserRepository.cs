using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<User>> GetAllUsers()
    {
        var result = await _dbContext.Users.ToListAsync();
        return result;
    }

    public async Task<User> GetByEmail(string email)
    {
        var result = _dbContext.Users.FirstOrDefault(u => u.Email == email);

        return result;
    }

    public async Task CreateUser(string fullName, string email, string password, byte[] salt)
    {
        var user = new User(fullName, email, password, salt);

        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> IsEmailUnique(string email)
    {
        return !await _dbContext.Users.AnyAsync(u => u.Email == email);
    }
}

