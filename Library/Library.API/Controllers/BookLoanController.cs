using Library.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var bookLoan = await _bookLoanService.GetByIdAsync(id);

        //    if (bookLoan == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(bookLoan);
        //}
    }
}
