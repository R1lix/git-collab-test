using BookStore.Core.Models;
using BookStore.DataAcces.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAcces.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder.HasKey(x => x.id);

            builder.Property(b => b.title)
                .HasMaxLength(Book.MAX_TITLE_LENGHT)
                .IsRequired();

            builder.Property(c => c.description)
                .HasMaxLength(Book.MAX_DESCRIPTION_LENGHT)
                .IsRequired();

            builder.Property(c => c.price)
                .IsRequired();
        }
    }
}
