using Library.Domain.Enumns;

namespace Library.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public BookStatus Status { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
    }
}
