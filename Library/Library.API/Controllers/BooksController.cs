using Library.Application.DTOs.InputModels;
using Library.Application.Services.Interfaces;
using Library.Domain.Entities;
using Library.Domain.Enumns;
using Library.Domain.Interfaces.Repositories;
using Library.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

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

        [HttpGet("{id:int}")]
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
        public async Task<IActionResult> Create([FromBody] CreateBookInputModel bookInputModel)
        {
            var book = await _bookService.CreateBookAsync(bookInputModel);

            return Ok(book);
        }

        [HttpGet("{genre}")]
        public async Task<IActionResult> GetByGenre(string genre)
        {
            var books = await _bookService.GetBooksByGenreAsync(genre);

            if (books.Count() <= 0)
            {
                return NoContent();
            }

            return Ok(books);
        }

        [HttpPost("{id:int}")]
        public IActionResult Update(int id)
        {
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
