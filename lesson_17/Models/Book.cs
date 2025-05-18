namespace lesson_17.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; private set; }

        public int Year { get; private set; }

        public string Genre { get; private set; }

        public List<Author> Authors { get; private set; }

        public bool IsBorrowed { get; set; }

        public string? Reader { get; set; }

        public Book(string title, List<Author> authors, string reader)
        {
            Title = title;
            Authors = authors;
            Reader = reader;
        }

    }
}
