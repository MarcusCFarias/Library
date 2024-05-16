using Library.Application.DTOs.InputModels.Books;
using Library.Application.Services.Interfaces;
using Library.Domain.Entities;
using Library.Domain.Enumns;
using Library.Domain.Interfaces.Repositories;
using Library.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, int pageSize = 10)
        {
            var books = await _bookService.GetAllAsync(page, pageSize);

            if (books.Count() <= 0)
            {
                return NoContent();
            }

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _bookService.GetByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookInputModel createBookInputModel)
        {
            var bookId = await _bookService.CreateBookAsync(createBookInputModel);

            return CreatedAtAction(nameof(GetById), new { id = bookId }, createBookInputModel);
        }

        [HttpGet("genre/{genre}")]
        public async Task<IActionResult> GetByGenre(string genre)
        {
            var books = await _bookService.GetBooksByGenreAsync(genre);

            if (books.Count() <= 0)
            {
                return NoContent();
            }

            return Ok(books);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBookInputModel updateBookInputModel)
        {
            await _bookService.UpdateBookAsync(id, updateBookInputModel);

            return AcceptedAtAction(nameof(GetById), new { id = id }, updateBookInputModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookService.DeleteBookAsync(id);

            return Ok();
        }
    }
}
