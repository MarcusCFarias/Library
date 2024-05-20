using FluentValidation;
using Library.Application.DTOs.InputModels.BookLoans;
using Library.Application.DTOs.InputModels.Books;
using Library.Domain.Enumns;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Validators
{
    public class CreateBookValidator : AbstractValidator<CreateBookInputModel>
    {
        public CreateBookValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty()
                .Length(5, 50)
                .WithMessage("Title must have between 5 and 50 characters.");

            RuleFor(x => x.Author)
                .NotNull()
                .NotEmpty()
                .Length(5, 50)
                .WithMessage("Author must have between 5 and 50 characters.");

            RuleFor(x => x.ISBN)
                .NotNull()
                .NotEmpty()
                .Length(13)
                .WithMessage("ISBN must have 13 characters.");

            RuleFor(x => x.Year)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .LessThanOrEqualTo(DateTime.Now.Year)
                .WithMessage("Year must be greater than 0 and less or equal than actual year.");

            RuleFor(x => x.Genre)
                .NotNull()
                .NotEmpty()
                .Length(5, 50)
                .WithMessage("Genre must have between 5 and 50 characters.");
        }
    }
    public class UpdateBookValidator : AbstractValidator<UpdateBookInputModel>
    {
        public UpdateBookValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty()
                .Length(5, 50)
                .WithMessage("Title must have between 5 and 50 characters.");

            RuleFor(x => x.Author)
                .NotNull()
                .NotEmpty()
                .Length(5, 50)
                .WithMessage("Author must have between 5 and 50 characters.");

            RuleFor(x => x.ISBN)
                .NotNull()
                .NotEmpty()
                .Length(13)
                .WithMessage("ISBN must have 13 characters.");

            RuleFor(x => x.Year)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .LessThanOrEqualTo(DateTime.Now.Year)
                .WithMessage("Year must be greater than 0 and less or equal than actual year.");

            RuleFor(x => x.Genre)
                .NotNull()
                .NotEmpty()
                .Length(5, 50)
                .WithMessage("Genre must have between 5 and 50 characters.");

            RuleFor(x => x.Status)
                .NotNull()
                .NotEmpty()
                .Must(x => Enum.IsDefined(typeof(BookStatus), x))
                .WithMessage("Status must be between 1 and 3.");
        }
    }

    public class  BookLoanValidator:AbstractValidator<CreateBookLoanInputModel>
    {
        public BookLoanValidator()
        {
            RuleFor(x => x.BookId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("BookId must be greater than 0.");

            RuleFor(x => x.UserId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("UserId must be greater than 0.");

            RuleFor(x => x.StartDate)
                .NotNull()
                .NotEmpty()
                .GreaterThan(DateTime.Now)
                .WithMessage("StartDate must be greater than actual date.");

            RuleFor(x => x.EndDate)
                .NotNull()
                .NotEmpty()
                .GreaterThan(DateTime.Now.AddDays(7))
                .WithMessage("EndDate must be greater than one week after start date");
        }
    }
}
