using System.ComponentModel;
using BookManagementAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementAPI.Service
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookByIdAsync(Guid id);
        Task CreateBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(Book book);

    }
    public class BookService : IBookService
    {
        private readonly BookDBContext _context;
        public BookService(BookDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return _context.Books;
        }

        public async Task<Book> GetBookByIdAsync(Guid id)
        {
              return await _context.Books.FindAsync(id);
        }

        public async Task CreateBookAsync(Book book)
        {
            await _context.Books.AddAsync(book);
        }

        public async Task UpdateBookAsync(Book book)
        {
            _context.Books.Update(book);
        }

        public async Task DeleteBookAsync(Book book)
        {
            _context.Books.Remove(book);
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
