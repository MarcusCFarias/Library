using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public class BookLoan : BaseEntity
    {
        public BookLoan(int bookId, int userId, DateOnly startDate, DateOnly endDate)
        {
            BookId = bookId;
            UserId = userId;
            StartDate = startDate;
            EndDate = endDate;
        }
        public int BookId { get; private set; }
        public Book Book { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }
        public DateOnly StartDate { get; private set; }
        public DateOnly EndDate { get; private set; }
        public DateOnly? ReturnDate { get; private set; }
        public decimal? Fine { get; private set; }

        public string ReturnBook(DateOnly returnDate)
        {
            ReturnDate = returnDate;

            if (returnDate > EndDate)
            {
                Fine = (returnDate.DayNumber - EndDate.DayNumber) * 0.5m;
                return $"The book was returned with a delay of {returnDate.DayNumber - EndDate.DayNumber} days. The fine is {Fine}";
            }

            return "The book was returned on time";
        }
    }
}
