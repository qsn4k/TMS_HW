namespace lesson_17.Models
{
    public class Reader
    {
        public int Id { get; set; }

        public string SurName { get; set; }

        public string Name { get; set; }

        public List<Book> Books = new List<Book>{};

        public Reader()
        {
        }
    }
}
