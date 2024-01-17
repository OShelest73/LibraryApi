using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users")
            .HasKey(u => u.Id);
        builder.HasAlternateKey(u => u.Email);
        builder.Property(u => u.FullName).IsRequired();
        builder.Property(u => u.Password).IsRequired();
    }
}
