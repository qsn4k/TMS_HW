using lesson_25.Data.Models;

namespace lesson_17.Repositories
{
    public interface IBookRepository
    {
        void Add(Book book);

        void Update(Book book);

        void Delete(int Id);

        void UpdateIsBorrowed(int Id, bool IsBorrowed, Reader? reader);

        Book Get(int Id);

        List<Book> GetAll();
    }
}
