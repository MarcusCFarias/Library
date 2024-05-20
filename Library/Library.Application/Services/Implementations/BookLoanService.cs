using Library.Application.DTOs.InputModels.BookLoans;
using Library.Application.DTOs.Mappings;
using Library.Application.DTOs.ViewModels.BookLoans;
using Library.Application.DTOs.ViewModels.Books;
using Library.Application.Services.Interfaces;
using Library.Domain.Entities;
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

        public Task<int> CreateBookLoanAsync(CreateBookLoanInputModel inputModel)
        {
            var bookLoan = inputModel.MappingCreateBookLoanInputModelToBookLoan();

            return _repositoryBookLoan.AddAsync(bookLoan);
        }

        public async Task<IEnumerable<GetBookLoanDetailViewModel>> GetAllDetailAsync(int page, int pageSize)
        {
            var bookLoans = await _repositoryBookLoan.GetAllDetailAsync(page, pageSize);

            var booksLoanDetailViewModel = bookLoans.MappingBookLoanToBookLoanDetail();

            return booksLoanDetailViewModel;
        }

        public async Task<string> ReturnBookAsync(int id)
        {
            var bookLoan = await _repositoryBookLoan.GetByIdAsync(id);

            if (bookLoan == null)
                throw new Exception("Book loan not found");

            var actualDate = DateOnly.FromDateTime(DateTime.Now);

            var message = bookLoan.ReturnBook(actualDate);

            _repositoryBookLoan.UpdateAsync(bookLoan);

            return message;
        }
    }
}
