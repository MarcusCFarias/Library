using Library.Application.DTOs.InputModels;
using Library.Application.DTOs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<GetBooksViewModel>> GetAllAsync(int page, int pageSize);
        Task<GetBookDetailViewModel> GetByIdAsync(int id);
        Task<int> CreateBookAsync(CreateBookInputModel createBookInputModel);
        Task<IEnumerable<GetBooksViewModel>> GetBooksByGenreAsync(string genre);
    }
}
