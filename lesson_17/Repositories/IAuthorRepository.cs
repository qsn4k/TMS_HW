using lesson_17.Models;

namespace lesson_17.Repositories
{
    public interface IAuthorRepository
    {
        void Add(Author author);

        void Update(Author author);

        void Delete(int Id);

        Author Get(int Id);

        List<Author> GetAll();
    }
}
