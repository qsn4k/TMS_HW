using lesson_17.Repositories;
using lesson_25.Data.Models;

namespace lesson_25.Repositories
{
    public class BdBookRepository : IBookRepository
    {
        public void Add(Book book)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Book Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Book book)
        {
            throw new NotImplementedException();
        }

        public void UpdateIsBorrowed(int Id, bool IsBorrowed, Reader? reader)
        {
            throw new NotImplementedException();
        }
    }
}
