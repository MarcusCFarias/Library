using Library.Application.DTOs.InputModels.Users;
using Library.Application.DTOs.Mappings;
using Library.Application.DTOs.ViewModels.Users;
using Library.Application.Services.Interfaces;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IRepositoryUser _repositoryUser;
        private readonly IAuthService _authService;
        public UserService(IRepositoryUser repositoryUser, IAuthService authService)
        {
            _repositoryUser = repositoryUser;
            _authService = authService;
        }
        public async Task<UserViewModel> GetByIdAsync(int id)
        {
            var user = await _repositoryUser.GetByIdAsync(id);

            if (user == null)
                throw new Exception("User not found");

            return user.MappingUserToUserViewModel();
        }

        public async Task<LoginViewModel> LoginAsync(UserLoginInputModel inputModel)
        {
            var passwordHash = _authService.ComputeSha256Hash(inputModel.Password);
            var user = await _repositoryUser.LoginAsync(inputModel.Email, passwordHash);

            if (user == null)
                return null;

            var token = _authService.GenerateJwtToken(user.Email, user.Role);
            var loginUserViewModel = new LoginViewModel
            {
                Email = user.Email,
                Token = token
            };

            return loginUserViewModel;
        }

        public async Task<int> RegisterUserAsync(UserRegisterInputModel inputModel)
        {
            var passwordHash = _authService.ComputeSha256Hash(inputModel.Password);
            var user = new User(inputModel.Name, inputModel.Email, passwordHash, inputModel.Role);

            return await _repositoryUser.AddAsync(user);
        }
    }
}
