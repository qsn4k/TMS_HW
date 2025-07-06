using lesson_28.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lesson_28.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly List<Book> books = new List<Book>
        {
            new Book { Id = 1, Author = "Пушкин", Title = "Золотая рыбка"},
            new Book { Id = 2, Author = "Толстой", Title = "Война и Мир"},
            new Book { Id = 3, Author = "Гоголь", Title = "Мёртвые души"}
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Book> GetById(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Book book)
        {
            books.Add(book);
            return Ok(books);
        }

        [HttpPut("{id}")]
        public ActionResult<Book> Put(int id, [FromBody] Book value)
        {
            var idBook = books.FindIndex(b => b.Id == id);
            books[idBook] = value;
            return Ok(books);
        }

        [HttpDelete("{id}")]
        public ActionResult<Book> Delete(int id)
        {
            var idBook = books.FindIndex(b => b.Id == id);
            books.RemoveAt(idBook);
            return Ok(books);
        }
    }
}
