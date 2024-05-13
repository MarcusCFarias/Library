using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTOs.ViewModels.BookLoans
{
    public class GetBookLoanDetailViewModel
    {
        public string BookName { get; set; }
        public string UserName { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public DateOnly? ReturnDate { get; set; }
        public decimal? Fine { get; set; }
    }
}
