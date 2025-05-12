namespace lesson_17.Models
{
    public class Book
    {
        public string Title { get; private set; }

        public List<Author> Authors { get; private set; }

        public Book(string title, List<Author> authors)
        {
            Title = title;
            Authors = authors;
        }
    }
}
