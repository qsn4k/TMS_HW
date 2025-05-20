using lesson_17.Models;

namespace lesson_17.ModelView
{
    public class ReaderBook
    {

        public Reader Reader { get; set; }

        public List<Book> Books { get; set; }

        public List<int> SelectBook { get; set; }

        public ReaderBook() { }
    }
}
