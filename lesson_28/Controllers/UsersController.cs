using lesson_28.Models;
using lesson_28.Service;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lesson_28.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IGet _get;

        public UsersController(IGet get)
        {
            _get = get;
        }

        [HttpGet]
        public ActionResult<User> GetAll()
        {
            var users = _get.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            var users = _get.GetUsers();
            var user = users.FirstOrDefault(b => b.Id == id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> Create([FromBody] User user)
        {
            var users = _get.GetUsers();
            users.Add(user);
            return Ok(users);
        }

        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody]User value)
        {
            var users = _get.GetUsers();
            var idUser = users.FindIndex(b => b.Id == id);
            users[idUser] = value;
            return Ok(users);
        }

        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            var users = _get.GetUsers();
            var idUser = users.FindIndex(b => b.Id == id);
            users.RemoveAt(idUser);
            return Ok(users);
        }
    }
}
