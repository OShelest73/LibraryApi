using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations;

public class BookConfiguration: IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("books")
            .HasKey(b => b.Id);
        builder.HasAlternateKey(b => b.ISBN);
        builder.Property(b => b.Genre).IsRequired();
        builder.Property(b => b.Description).IsRequired();
        builder.Property(b => b.Author).IsRequired();
    }
}
