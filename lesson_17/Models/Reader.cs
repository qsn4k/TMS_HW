namespace lesson_17.Models
{
    public class Reader
    {
        public int Id { get; set; }

        public string Name { get; set; }

        private List<Book> Books = new List<Book>
        {

        };

        public Reader(string name, List<Book> books)
        {
            Name = name;
            Books = books;
        }
    }
}
