using System.ComponentModel.DataAnnotations;

namespace lesson_25.Data.Models
{
    public class Reader
    {
        [Key]
        public int Id { get; set; }

        public string SurName { get; set; }

        public string Name { get; set; }

        public List<Book> Books = new List<Book>{};

        public Reader()
        {
        }
    }
}
