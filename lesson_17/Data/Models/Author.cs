using System.ComponentModel.DataAnnotations;

namespace lesson_25.Data.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        public string SurName { get; set; }

        public string Name { get; set; }

        public int BirthYear { get; set; }

        public string Country { get; set; }

        public List<Book> Books { get; set; } = new List<Book> { };
    }
}
