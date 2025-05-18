using lesson_17.Models;

namespace lesson_17.Repositories
{
    public interface IBookRepository
    {
        void Add(Book book);

        void Delete(Book book);

        void Update(Book book);

        void Get(Book book);

        List<Book> GetAll();
    }
}
