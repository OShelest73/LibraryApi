using Domain.Abstractions;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, string connectionString)
    {       
        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(connectionString));

        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
