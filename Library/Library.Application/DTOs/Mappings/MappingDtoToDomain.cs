using Library.Application.DTOs.InputModels.BookLoans;
using Library.Application.DTOs.InputModels.Books;
using Library.Application.DTOs.ViewModels.BookLoans;
using Library.Application.DTOs.ViewModels.Books;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTOs.Mappings
{
    internal static class BooksMappingDtoToDomain
    {
        internal static Book MappingCreateBookInputModelToBook(this CreateBookInputModel inputModel)
        {
            var book = new Book(inputModel.Title,
                inputModel.Author,
                inputModel.ISBN,
                inputModel.Year,
                inputModel.Genre);

            return book;
        }

        internal static IEnumerable<GetBooksViewModel> MappingBooksToBooksViewModel(this IEnumerable<Book> books)
        {
            var booksViewModel = books.Select(book => new GetBooksViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                Year = book.Year
            });

            return booksViewModel;
        }

        internal static GetBookDetailViewModel MappingBooksToBookDetailViewModel(this Book book)
        {
            var bookDetailViewModel = new GetBookDetailViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                ISBN = book.ISBN,
                Year = book.Year,
                Status = book.Status
            };

            return bookDetailViewModel;
        }

        internal static IEnumerable<GetBookLoanDetailViewModel> MappingBookLoanToBookLoanDetail(this IEnumerable<BookLoan> booksLoan)
        {
            var bookLoanDetail = booksLoan.Select(x => new GetBookLoanDetailViewModel
            {
                BookName = x.Book.Title,
                UserName = x.User.Name,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                ReturnDate = x.ReturnDate,
                Fine = x.Fine
            });

            return bookLoanDetail;
        }
        internal static BookLoan MappingCreateBookLoanInputModelToBookLoan(this CreateBookLoanInputModel inputModel)
        {
            var bookLoan = new BookLoan(inputModel.BookId, 
                inputModel.UserId, 
                new DateOnly(inputModel.StartDate.Year, inputModel.StartDate.Month, inputModel.StartDate.Day),
                new DateOnly(inputModel.EndDate.Year, inputModel.EndDate.Month, inputModel.EndDate.Day));

            return bookLoan;
        }
    }
}
