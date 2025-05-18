using lesson_17.Models;
using lesson_17.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace lesson_17.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            List<Author> authors = _authorRepository.GetAll();
            return View(authors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            _authorRepository.Add(author);
            return RedirectToAction("List");
        }

        public IActionResult Delete(Author author)
        {
            return RedirectToAction("List");
        }
    }
}
