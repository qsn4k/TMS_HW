using lesson_17.Models;

namespace lesson_17.Repositories
{
    public interface IReaderRepository
    {
        void Add(Reader reader);

        void Update(Reader reader);

        void Delete(Reader reader);

        void Get(Reader reader);

        List<Reader> GetAll();

    }

}
