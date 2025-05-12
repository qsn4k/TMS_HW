using lesson_17.Repositories;
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

        public IActionResult Index()
        {
            return View();
        }
    }
}
