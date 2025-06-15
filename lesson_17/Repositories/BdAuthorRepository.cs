using lesson_17.Repositories;
using lesson_25.Data;
using lesson_25.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace lesson_25.Repositories
{
    public class BdAuthorRepository : IAuthorRepository
    {

        public void Add(Author author)
        {
            using(var contex = new ApplicationContex())
            {
                contex.Authors.Add(author);
                contex.SaveChanges();
            }
        }

        public void Delete(int Id)
        {
            using(var contex = new ApplicationContex())
            {
                contex.Authors.Where(x => x.Id == Id).ExecuteDelete();
            }
        }

        public Author Get(int Id)
        {
            using(var contex = new ApplicationContex())
            {
                var author = contex.Authors.First(x => x.Id == Id);
                if (author != null) return author;
                else return new Author();
            }
        }

        public List<Author> GetAll()
        {
            using(var contex = new ApplicationContex())
            {
                return contex.Authors.ToList();
            }
        }

        public void Update(Author author)
        {
            var id = author.Id;
            using(var contex = new ApplicationContex())
            {
                var newAuthor = contex.Authors.First(x => x.Id == id);
                if(newAuthor != null)
                {
                    newAuthor = author;
                    contex.SaveChanges();
                }
            }
        }
    }
}
