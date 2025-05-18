using lesson_17.Models;

namespace lesson_17.Repositories
{
    public class BookRepository : IBookRepository
    {
        private static List<Book> books = new List<Book>
        {

        };

        public void Add(Book book)
        {

        }

        public void Delete(Book book)
        {

        }

        public void Update(Book book)
        {

        }

        public void Get(Book book)
        {

        }

        public List<Book> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
