using Library.Application.DTOs.InputModels.Users;
using Library.Application.DTOs.ViewModels.Users;
using Library.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "admin")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            return Ok(user);
        }
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRegisterInputModel inputModel)
        {
            int userId = await _userService.RegisterUserAsync(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = userId }, inputModel);
        }
        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginInputModel userLoginInputModel)
        {
            var loginUserViewModel = await _userService.LoginAsync(userLoginInputModel);

            if (loginUserViewModel == null)
            {
                return Unauthorized("Usuário ou senha incorretos!");
            }

            return Ok(loginUserViewModel);
        }
    }
}
