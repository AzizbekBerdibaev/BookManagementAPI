using BookManagementAPI.Configurations;
using BookManagementAPI.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace BookManagementAPI
{
    public class BookDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public BookDBContext(DbContextOptions<BookDBContext> options) : base(options) { }
        
    }
}
