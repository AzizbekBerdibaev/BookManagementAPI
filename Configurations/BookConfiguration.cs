using BookManagementAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManagementAPI.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Title)
                .HasColumnType("string")
                .IsRequired();

            builder.Property(r => r.Author)
                .HasColumnType("string")
                .IsRequired();

            builder.Property(r => r.PublishedYear)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(r => r.ISBN)
                .HasColumnType("string")
                .IsRequired();

            builder.Property(r => r.Price)
                .HasColumnType("decimal")
                .IsRequired();


            throw new NotImplementedException();
        }
    }
}
