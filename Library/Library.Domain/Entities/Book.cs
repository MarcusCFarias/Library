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
        public string Title { get; set; }
        public string Author { get; set; }
        public BookStatus Status { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
    }
}
