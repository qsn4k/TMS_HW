namespace lesson_17.Models
{
    public class Author
    {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public Author(string name, int age  )
        {
            Name = name;
            Age = age;
        }
    }
}
