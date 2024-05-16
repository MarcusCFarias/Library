using Library.Application.DTOs.InputModels.Users;
using Library.Application.DTOs.ViewModels.Books;
using Library.Application.DTOs.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetByIdAsync(int id);
        Task<int> RegisterUserAsync(UserRegisterInputModel inputModel);
        Task<LoginViewModel> LoginAsync(UserLoginInputModel inputModel);
    }
}
