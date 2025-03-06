using System.Collections;
using BookManagementAPI.Dtos;
using BookManagementAPI.Entities;
using BookManagementAPI.Service;
using BookManagementAPI.Validators;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _service;
        public BooksController(BookService service)
        {
            _service = service;
        }

        [HttpGet("books")]
        public async Task<IActionResult> GetBooksAsync()
        {
            var books = await _service.GetBooksAsync();
            return Ok(books);
        }

        [HttpGet("books/{id}")]

        public async Task<IActionResult> GetBookByIdAsync([FromQuery] Guid id)
        {
            var book = await _service.GetBookByIdAsync(id);

            if(book == null) 
            { 
                return NotFound(); 
            }

            var bookDto = new BookDto()
            {
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                PublishedYear = book.PublishedYear,
                Price = book.Price
            };

            return Ok(bookDto);
        }

        [HttpPost("create-book")]
        public async Task<IActionResult> CreateBookAsync([FromBody] CreateBookDto createBookDto)
        {
            var createBookDtoValidator = new CreateBookDtoValidator();
            var resultValidation = await createBookDtoValidator.ValidateAsync(createBookDto);

            if(!resultValidation.IsValid)
            {
                return BadRequest();
            }

            var newBook = new Book()
            {
                Title = createBookDto.Title,
                Author = createBookDto.Author,
                ISBN = createBookDto.ISBN,
                Price = createBookDto.Price,
                PublishedYear = createBookDto.PublishedYear,
                Genre = createBookDto.Genre
            };

            await _service.CreateBookAsync(newBook);
            await _service.SaveChangesAsync();

            return Ok(newBook);
        }

        [HttpPut("update-book/{id}")]
        public async Task<IActionResult> UpdateBookAsync([FromQuery] Guid id, [FromBody] UpdateBookDto updateBookDto)
        {
            var updateBookDtoValidator = new UpdateBookDtoValidator();
            var resultValidation = await updateBookDtoValidator.ValidateAsync(updateBookDto);

            if(!resultValidation.IsValid)
            {
                return BadRequest();
            }

            var updateBook = await _service.GetBookByIdAsync(id);

            if(updateBook == null)
            {
                return NotFound();
            }

            updateBook.Title = updateBookDto.Title;
            updateBook.Author = updateBookDto.Author;
            updateBook.ISBN = updateBookDto.ISBN;
            updateBook.PublishedYear = updateBookDto.PublishedYear;
            updateBook.Price = updateBookDto.Price;

            await _service.UpdateBookAsync(updateBook);
            await _service.SaveChangesAsync();

            return Ok(updateBook);
        }

        [HttpDelete("delete-book/{id}")]
        public async Task<IActionResult> DeleteBookAsync([FromRoute] Guid id)
        {
            var deleteBook = await _service.GetBookByIdAsync(id);
            
            if(deleteBook == null)
            {
                return NotFound();
            }

            await _service.DeleteBookAsync(deleteBook);
            await _service.SaveChangesAsync();

            return Ok(deleteBook);
        }
    }
}
