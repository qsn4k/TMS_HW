using lesson_28.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lesson_28.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly List<User> users = new List<User>
        {
            new User{Id = 1, Name = "Danik", BirthYear = 2006},
            new User{Id = 2, Name = "Anna", BirthYear = 1982},
            new User{Id = 3, Name = "Andrey", BirthYear = 2013},
        };

        [HttpGet]
        public ActionResult<User> GetAll()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            var user = users.FirstOrDefault(b => b.Id == id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> Create([FromBody] User user)
        {
            users.Add(user);
            return Ok(users);
        }

        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody]User value)
        {
            var idUser = users.FindIndex(b => b.Id == id);
            users[idUser] = value;
            return Ok(users);
        }

        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            var idUser = users.FindIndex(b => b.Id == id);
            users.RemoveAt(idUser);
            return Ok(users);
        }
    }
}
