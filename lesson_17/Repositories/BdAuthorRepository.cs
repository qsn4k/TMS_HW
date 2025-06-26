using lesson_17.Repositories;
using lesson_25.Data;
using lesson_25.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace lesson_25.Repositories
{
    public class BdAuthorRepository : IAuthorRepository
    {
        private readonly ApplicationContex contex;

        public BdAuthorRepository(ApplicationContex _contex)
        {
            contex = _contex;
        }

        public void Add(Author author)
        {
            using (contex)
            {
                contex.Authors.Add(author);
                contex.SaveChanges();
            }
        }

        public void Delete(int Id)
        {
            using (contex)
            {
                contex.Authors.Where(x => x.Id == Id).ExecuteDelete();
            }
        }

        public Author Get(int Id)
        {
            using (contex)
            {
                var author = contex.Authors.First(x => x.Id == Id);
                if (author != null) return author;
                else return new Author();
            }
        }

        public List<Author> GetAll()
        {
            using (contex)
            {
                return contex.Authors.ToList();
            }
        }

        public void Update(Author author)
        {
            var id = author.Id;
            using (contex)
            {
                var newAuthor = contex.Authors.First(x => x.Id == id);
                if (newAuthor != null)
                {
                    newAuthor = author;
                    contex.SaveChanges();
                }
            }
        }
    }
}
