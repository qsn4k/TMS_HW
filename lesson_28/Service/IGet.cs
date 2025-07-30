using lesson_28.Models;

namespace lesson_28.Service
{
    public interface IGet
    {
        List<Book> GetBooks();

        List<User> GetUsers();

    }
}
