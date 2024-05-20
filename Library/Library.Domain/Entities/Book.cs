using Library.Domain.Enumns;

namespace Library.Domain.Entities
{
    public class Book : BaseEntity
    {
        public Book(string title, string author, string ISBN, int year, string genre)
        {
            Title = title;
            Author = author;
            Status = BookStatus.Available;
            this.ISBN = ISBN;
            Year = year;
            Genre = genre;
        }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public BookStatus Status { get; private set; }
        public string ISBN { get; private set; }
        public int Year { get; private set; }
        public string Genre { get; private set; }
        public ICollection<BookLoan> BookLoans { get; private set; }
        public void UpdateBook(string title, string author, BookStatus bookStatus, string ISBN, int year, string genre)
        {
            Title = title;
            Author = author;
            Status = bookStatus;
            this.ISBN = ISBN;
            Year = year;
            Genre = genre;
        }
    }
}
