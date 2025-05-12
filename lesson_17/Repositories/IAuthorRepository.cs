
using lesson_17.Models;

namespace lesson_17.Repositories
{
    public interface IAuthorRepository
    {
        void Add(Author author);

        void Update(Author author);

        void Delete(Author author);

        void Get(Author author);
    }
}
