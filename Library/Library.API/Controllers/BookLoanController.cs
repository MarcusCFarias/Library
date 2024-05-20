using Library.Application.DTOs.InputModels.BookLoans;
using Library.Application.DTOs.InputModels.Books;
using Library.Application.Services.Implementations;
using Library.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookLoanController : ControllerBase
    {
        private readonly IBookLoanService _bookLoanService;
        public BookLoanController(IBookLoanService bookLoanService)
        {
            _bookLoanService = bookLoanService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, int pageSize = 10)
        {
            var bookLoans = await _bookLoanService.GetAllDetailAsync(page, pageSize);

            if (bookLoans.Count() <= 0)
            {
                return NoContent();
            }

            return Ok(bookLoans);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookLoanInputModel inputModel)
        {
            var bookId = await _bookLoanService.CreateBookLoanAsync(inputModel);

            return Ok(string.Format("Loan id {0}", 0));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ReturnBook(int id)
        {
            var message = await _bookLoanService.ReturnBookAsync(id);

            return Ok(message);
        }
    }
}
