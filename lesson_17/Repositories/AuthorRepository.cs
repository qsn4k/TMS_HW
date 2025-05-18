using lesson_17.Models;
using lesson_17.Repositories;

namespace lesson_17.Repositoryies
{
    public class AuthorRepository : IAuthorRepository
    {
        private static List<Author> authors = new List<Author>
        {
              
        };

        public void Add(Author author)
        {
            authors.Add(author);
        }

        public void Delete(Author author)
        {
            throw new NotImplementedException();
        }

        public void Get(Author author)
        {
            throw new NotImplementedException();
        }

        public List<Author> GetAll()
        {
            return authors;
        }

        public void Update(Author author)
        {
            throw new NotImplementedException();
        }
    }   
}
