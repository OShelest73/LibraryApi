using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions;

public interface IUserRepository
{
    Task<List<User>> GetAllUsersAsync();
    Task<User> GetByEmailAsync(string email);
    Task CreateUserAsync(string fullName, string email, string password, byte[] salt);
    Task<bool> IsEmailUniqueAsync(string email);
}
