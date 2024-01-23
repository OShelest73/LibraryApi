using Application.Dtos.Book;
using Application.Dtos.User;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Settings;

public class ApplicationMappingProfile: Profile
{
    public ApplicationMappingProfile()
    {
        CreateMap<Book, BookDto>().ReverseMap();
        CreateMap<Book, CreateBookDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, RegisterDto>().ReverseMap();
    }
}
