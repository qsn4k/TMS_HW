using lesson_28.Models;
using lesson_28.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lesson_28.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IGet _get;

        public BooksController(IGet get)
        {
            _get = get;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _get.GetBooks();
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Book> GetById(int id)
        {
            var books = _get.GetBooks();
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Book book)
        {
            var books = _get.GetBooks();
            books.Add(book);
            return Ok(books);
        }

        [HttpPut("{id}")]
        public ActionResult<Book> Put(int id, [FromBody] Book value)
        {
            var books = _get.GetBooks();
            var idBook = books.FindIndex(b => b.Id == id);
            books[idBook] = value;
            return Ok(books);
        }

        [HttpDelete("{id}")]
        public ActionResult<Book> Delete(int id)
        {
            var books = _get.GetBooks();
            var idBook = books.FindIndex(b => b.Id == id);
            books.RemoveAt(idBook);
            return Ok(books);
        }
    }
}
