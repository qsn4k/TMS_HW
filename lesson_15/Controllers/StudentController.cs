using lesson_15.Models;
using Microsoft.AspNetCore.Mvc;
using lesson_15.Repositories;

namespace lesson_15.Controllers
{
    public class StudentController : Controller
    {



        public IActionResult Index()
        {
            var students = StudentReporsitory.GetAll();

            return View(students);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            StudentReporsitory.Edit(student);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            StudentReporsitory.Add(student);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            StudentReporsitory.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var students = StudentReporsitory.GetAll();
            var student = students.FirstOrDefault(st => st.Id == id);
            return View(student);
        }

    }
}
