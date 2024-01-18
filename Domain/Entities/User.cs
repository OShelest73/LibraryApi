using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class User
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public byte[] Salt {  get; set; }

    public User(string fullName, string email, string password)
    {
        FullName = fullName;
        Email = email;
        Password = password;
    }

    public User(string fullName, string email, string password, byte[] salt)
    {
        FullName = fullName;
        Email = email;
        Password = password;
        Salt = salt;
    }
}
