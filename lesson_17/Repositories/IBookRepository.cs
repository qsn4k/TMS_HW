using lesson_17.Models;

namespace lesson_17.Repositories
{
    public interface IBookRepository
    {
        void Add(Book book);

        void Update(Book book);

        void Delete(int Id);

        Book Get(int Id);

        List<Book> GetAll();
    }
}
