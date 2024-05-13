using Library.Application.DTOs.ViewModels.BookLoans;
using Library.Application.DTOs.ViewModels.Books;
using Library.Application.Services.Interfaces;
using Library.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services.Implementations
{
    public class BookLoanService : IBookLoanService
    {
        private readonly IRepositoryBookLoan _repositoryBookLoan;
        public BookLoanService(IRepositoryBookLoan repositoryBookLoan)
        {
            _repositoryBookLoan = repositoryBookLoan;
        }
        public async Task<IEnumerable<GetBookLoanDetailViewModel>> GetAllDetailAsync(int page, int pageSize)
        {
            var bookLoans = await _repositoryBookLoan.GetAllDetailAsync(page, pageSize);

            


            return (IEnumerable<GetBookLoanDetailViewModel>)bookLoans;
        }
    }
}
