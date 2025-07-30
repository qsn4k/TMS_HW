using lesson_28.Models;

namespace lesson_28.Service
{
    public class GetService : IGet
    {
        private readonly List<Book> books = new List<Book>
        {
            new Book { Id = 1, Author = "Пушкин", Title = "Золотая рыбка"},
            new Book { Id = 2, Author = "Толстой", Title = "Война и Мир"},
            new Book { Id = 3, Author = "Гоголь", Title = "Мёртвые души"}
        };

        private readonly List<User> users = new List<User>
        {
            new User{Id = 1, Name = "Danik", BirthYear = 2006},
            new User{Id = 2, Name = "Anna", BirthYear = 1982},
            new User{Id = 3, Name = "Andrey", BirthYear = 2013},
        };

        public List<Book> GetBooks()
        {
            return books;
        }

        public List<User> GetUsers()
        {
            return users;
        }
    }
}
