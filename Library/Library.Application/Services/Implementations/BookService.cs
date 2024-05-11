using Library.Application.DTOs.InputModels;
using Library.Application.DTOs.ViewModels;
using Library.Application.Services.Interfaces;
using Library.Domain.Entities;
using Library.Domain.Enumns;
using Library.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IRepositoryBook _bookRepository;
        public BookService(IRepositoryBook repositoryBook)
        {
            _bookRepository = repositoryBook;
        }
        public async Task<int> CreateBookAsync(CreateBookInputModel inputModel)
        {
            var existingBook = await _bookRepository.GetByISBNAsync(inputModel.ISBN);

            if (existingBook != null)
                throw new Exception("Book already created, change the ISBN.");

            var book = new Book(inputModel.Title,
                inputModel.Title,
                inputModel.ISBN,
                inputModel.Year,
                inputModel.Genre);

            return await _bookRepository.AddAsync(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
                throw new Exception("Book not found");

            book.UpdateBook(book.Title,
                book.Author,
                BookStatus.Unavailable,
                book.ISBN,
                book.Year,
                book.Genre);

            await _bookRepository.UpdateAsync(book);
        }

        public async Task<IEnumerable<GetBooksViewModel>> GetAllAsync(int page, int pageSize)
        {
            var books = await _bookRepository.GetAllAsync(page, pageSize);

            var booksViewModel = books.Select(book => new GetBooksViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                Year = book.Year
            });

            return booksViewModel;
        }
        public async Task<IEnumerable<GetBooksViewModel>> GetBooksByGenreAsync(string genre)
        {
            var books = await _bookRepository.GetByGenreAsync(genre);

            var booksViewModel = books.Select(book => new GetBooksViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                Year = book.Year
            });

            return booksViewModel;
        }
        public async Task<GetBookDetailViewModel> GetByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
                return null;

            var bookViewModel = new GetBookDetailViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                Year = book.Year,
                Author = book.Author,
                ISBN = book.ISBN,
                Status = book.Status
            };

            return bookViewModel;
        }
        public async Task UpdateBookAsync(int id, UpdateBookInputModel updateBookInputModel)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
                throw new Exception("Book not found");

            book.UpdateBook(updateBookInputModel.Title,
                updateBookInputModel.Author,
                updateBookInputModel.Status,
                updateBookInputModel.ISBN,
                updateBookInputModel.Year,
                updateBookInputModel.Genre);

            await _bookRepository.UpdateAsync(book);
        }
    }
}
