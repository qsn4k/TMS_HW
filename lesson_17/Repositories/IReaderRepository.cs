using lesson_25.Data.Models;

namespace lesson_17.Repositories
{
    public interface IReaderRepository
    {
        void Add(Reader reader);

        void Update(Reader reader);

        void Delete(int Id);

        Reader Get(int Id);

        List<Reader> GetAll();

    }

}
