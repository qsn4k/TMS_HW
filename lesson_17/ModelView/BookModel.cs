using lesson_17.Models;

namespace lesson_17.ModelView
{
    public class BookModel
    {
        public string Title { get; private set; }


        public List<Author> Authors { get; private set; }

        public bool IsBorrowed { get; set; }

        public BookModel()
        {

        }

        public BookModel(Book book)
        {
            Title = book.Title;
            Authors = book.Authors;
            IsBorrowed = book.IsBorrowed;
        }
    }
}
