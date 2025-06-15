using lesson_25.Data.Models;

namespace lesson_17.ModelView
{
    public class BookModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<Author> Authors { get; set; } = new List<Author> { };

        public bool IsBorrowed { get; set; }

        public BookModel() { }

        public BookModel(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            Authors = book.Authors;
            IsBorrowed = book.IsBorrowed;
        }
    }
}
