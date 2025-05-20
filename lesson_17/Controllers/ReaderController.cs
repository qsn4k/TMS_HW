using lesson_17.Models;
using lesson_17.ModelView;
using lesson_17.Repositories;
using lesson_17.Repositoryies;
using Microsoft.AspNetCore.Mvc;

namespace lesson_17.Controllers
{
    public class ReaderController : Controller
    {
        private readonly IReaderRepository _readerRepository;

        private readonly IBookRepository _bookRepository;

        public ReaderController(IReaderRepository readerRepository, IBookRepository bookRepository)
        {
            _readerRepository = readerRepository;
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            List<Reader> readers = _readerRepository.GetAll();
            return View(readers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Reader reader)
        {
            _readerRepository.Add(reader);
            return RedirectToAction("List");
        }

        public IActionResult Details(int id)
        {
            var reader = _readerRepository.Get(id);
            return View(reader);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var reader = _readerRepository.Get(id);
            return View(reader);
        }
        public IActionResult Delete(int id)
        {
            _readerRepository.Delete(id);
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult Edit(Reader reader)
        {
            _readerRepository.Update(reader);
            return RedirectToAction("Details", reader.Id); // Изменить на details

        }

        [HttpGet]
        public IActionResult TakeBook(int Id)
        {
            var reader = _readerRepository.Get(Id);
            ReaderBook readerBook = new ReaderBook();
            readerBook.Reader = reader;
            readerBook.Books = _bookRepository.GetAll().Where(book => book.IsBorrowed == false).ToList();
            return View(readerBook);
        }

        [HttpPost]
        public IActionResult TakeBook(ReaderBook readerBook)
        {
            Reader reader = new Reader() { };
            reader = readerBook.Reader;
            reader.Books.Add(_bookRepository.Get(readerBook.SelectBook));
            _readerRepository.Update(reader);
            _bookRepository.UpdateIsBorrowed(readerBook.SelectBook, true);
            return RedirectToAction("Details", readerBook.Reader.Id);
        }


        [HttpGet]        
        public IActionResult GiveBook(Reader reader)
        {
            return RedirectToAction("Details", reader.Id);
        }

    }
}
