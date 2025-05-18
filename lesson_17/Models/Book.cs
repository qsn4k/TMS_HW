

using lesson_17.ModelView;

namespace lesson_17.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public List<Author> Authors { get; set; }

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
