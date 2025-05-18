using lesson_17.Models;
using lesson_17.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace lesson_17.Controllers
{
    public class ReaderController : Controller
    {
        private readonly IReaderRepository _readerRepository;

        public ReaderController(IReaderRepository readerRepository)
        {
            _readerRepository = readerRepository;
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
    }
}
