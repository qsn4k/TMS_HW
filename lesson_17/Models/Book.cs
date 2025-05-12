namespace lesson_17.Models
{
    public class Book
    {
        public string Title { get; private set; }

        public List<Author> Authors { get; private set; }

        public string Reader { get; private set; }

        public Book(string title, List<Author> authors, string reader)
        {
            Title = title;
            Authors = authors;
            Reader = reader;
        }

    }
}
