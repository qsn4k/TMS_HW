using lesson_17.Repositories;
using lesson_25.Data;
using lesson_25.Data.Models;
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

        public IActionResult Details(int id)
        {
            var author = _authorRepository.Get(id);
            return View(author);
        }

        public IActionResult Delete(int id)
        {
            _authorRepository.Delete(id);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var author = _authorRepository.Get(id);
            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            _authorRepository.Update(author);
            return RedirectToAction("List"); // Изменить на details

        }
    }
}
