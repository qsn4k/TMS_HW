using lesson_17.ModelView;
using System.ComponentModel.DataAnnotations;

namespace lesson_25.Data.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public List<Author> Authors { get; set; } = new List<Author> { };

        public bool IsBorrowed { get; set; }

        public Reader? Reader { get; set; }

        public Book() { }

        public Book(BookModel bookModel)
        {
            Id = bookModel.Id;
            Title = bookModel.Title;
            Authors = bookModel.Authors;
            IsBorrowed = bookModel.IsBorrowed;
        }


    }
}
