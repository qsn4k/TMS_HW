using lesson_17.Models;
using lesson_17.ModelView;
using lesson_17.Repositories;
using lesson_17.Repositoryies;
using Microsoft.AspNetCore.Mvc;

namespace lesson_17.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult List()
        {
            List<BookModel> books = _bookRepository.GetAll().Select(book => new BookModel(book)).ToList();
            return View(books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            BookAuthorView bookAuthorView = new BookAuthorView();
            bookAuthorView.Authors = new AuthorRepository().GetAll();
            return View(bookAuthorView);
        }

        [HttpPost]
        public IActionResult Create(BookAuthorView bookAuthorView)
        {
            Book book = bookAuthorView.Book;
            List<Author> authors = new AuthorRepository().GetAll()
                .Where(author => bookAuthorView.SelectAuthors.Contains(author.Id))
                .ToList();
            book.Authors = authors;
            _bookRepository.Add(book);
            return RedirectToAction("List");
        }

        public IActionResult Details(int id)
        {
            var book = _bookRepository.Get(id);
            return View(book);
        }

        public IActionResult Delete(int id)
        {
            _bookRepository.Delete(id);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _bookRepository.Get(id);
            BookAuthorView bookAuthorView = new BookAuthorView();
            bookAuthorView.Authors = new AuthorRepository().GetAll();
            bookAuthorView.Book = book;
            return View(bookAuthorView);
        }

        [HttpPost]
        public IActionResult Edit(BookAuthorView bookAuthorView)
        {
            Book book = bookAuthorView.Book;
            List<Author> authors = new AuthorRepository().GetAll()
                .Where(author => bookAuthorView.SelectAuthors.Contains(author.Id))
                .ToList();
            book.Authors = authors;
            _bookRepository.Update(book);
            return RedirectToAction("List"); // Изменить на details
        }
    }
}
