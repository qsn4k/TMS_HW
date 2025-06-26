using lesson_17.Repositories;
using lesson_25.Data;
using lesson_25.Data.Models;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace lesson_25.Repositories
{
    public class BdBookRepository : IBookRepository
    {
        private readonly ApplicationContex contex;

        public BdBookRepository(ApplicationContex _contex)
        {
            contex = _contex;
        }
        public void Add(Book book)
        {
            using (contex)
            {
                contex.Books.Add(book);
                contex.SaveChanges();
            }
        }

        public void Delete(int Id)
        {
            using (contex)
            {
                contex.Books.Where(x => x.Id == Id).ExecuteDelete();
            }
        }

        public Book Get(int Id)
        {
            using (contex)
            {
                var book = contex.Books.First(x => x.Id == Id);
                if (book != null) return book;
                else return new Book();
            }
        }

        public List<Book> GetAll()
        {
            using (contex)
            {
                return contex.Books.ToList();
            }
        }

        public void Update(Book book)
        {
            var id = book.Id;
            using (contex)
            {
                var newBook = contex.Books.First(x => x.Id == id);
                if (newBook != null)
                {
                    newBook = book;
                    contex.SaveChanges();
                }
            }
        }

        public void UpdateIsBorrowed(int Id, bool IsBorrowed, Reader? reader)
        {
            using (contex)
            {
                var books = contex.Books.ToList();
                int index = books.FindIndex(book => book.Id == Id);
                books[index].IsBorrowed = IsBorrowed;
                books[index].Reader = reader;
            }
                
        }
    }
}
