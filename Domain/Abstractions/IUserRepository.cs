using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions;

public interface IUserRepository
{
    Task<List<User>> GetAllUsersAsync(CancellationToken cancellationToken);
    Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken);
    Task CreateUserAsync(string fullName, string email, string password, byte[] salt, CancellationToken cancellationToken);
    Task<bool> IsEmailUniqueAsync(string email);
}
