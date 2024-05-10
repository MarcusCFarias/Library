using Library.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public BooksController(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll() //with pagination
        {
            var teste = _appDbContext.Database;



            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create()
        {
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
