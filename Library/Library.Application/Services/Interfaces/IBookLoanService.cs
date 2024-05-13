using Library.Application.DTOs.ViewModels.BookLoans;
using Library.Application.DTOs.ViewModels.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services.Interfaces
{
    public interface IBookLoanService
    {
        Task<IEnumerable<GetBookLoanDetailViewModel>> GetAllDetailAsync(int page, int pageSize);
        //Task<GetBookLoanDetailViewModel> GetByIdAsync(int id);
    }
}
