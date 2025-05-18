using lesson_17.Models;

namespace lesson_17.ModelView
{
    public class BookAuthorView
    {
        public Book Book { get; set; }

        public List<Author> Authors { get; set; }

        public List<int> SelectAuthors { get; set; }

        public BookAuthorView() { }
    }
}
