﻿using Domain.Entities;
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
        builder.ToTable("Books")
            .HasKey(b => b.Id);
        //I don't know if this types are important for this system so simply owned types instead of foreign constraints 
        builder.OwnsOne(b => b.Author, authorBuilder =>
        {
            authorBuilder.Property(a => a.FirstName).IsRequired();
            authorBuilder.Property(a => a.LastName).IsRequired();
        });
        builder.OwnsOne(b => b.Genre, genreBuilder =>
        {
            genreBuilder.Property(g => g.GenreName).IsRequired();
        });

        builder.Property(b => b.Isbn).IsRequired();
        builder.Property(b => b.Description).IsRequired();
    }
}
