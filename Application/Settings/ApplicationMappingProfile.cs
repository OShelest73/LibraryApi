using Application.Dtos.Book;
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
    }
}
