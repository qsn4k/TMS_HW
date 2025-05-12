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
    }
}
