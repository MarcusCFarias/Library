using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public class Loan : BaseEntity
    {
        public Loan(int bookId, int userId, DateOnly startDate, DateOnly endDate)
        {
            BookId = bookId;
            UserId = userId;
            StartDate = startDate;
            EndDate = endDate;
        }
        public int BookId { get; private set; }
        public int UserId { get; private set; }
        public DateOnly StartDate { get; private set; }
        public DateOnly EndDate { get; private set; }
        public DateOnly? ReturnDate { get; private set; }
        public decimal? Fine { get; private set; }
    }
}
