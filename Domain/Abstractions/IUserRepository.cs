using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions;

public interface IUserRepository
{
    Task<List<User>> GetAllUsers();
    Task<User> GetByEmail(string email);
    Task CreateUser(string fullName, string email, string password, byte[] salt);
    Task<bool> IsEmailUnique(string email);
}
