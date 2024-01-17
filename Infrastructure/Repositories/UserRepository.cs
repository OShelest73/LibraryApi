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

    public async Task CreateUser(string fullName, string email, string password)
    {
        var user = new User(fullName, email, password);

        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }
}

