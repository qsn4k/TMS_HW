using lesson_15.Models;

namespace lesson_15.Repositories
{
    public static class StudentReporsitory
    {
        private static List<Student> students = new List<Student>
        {
                new Student {Id = 1, Name = "Денисенко Даниил", Age = 19, IsStudying = true},
                new Student {Id = 2, Name = "Круталевич Дарья", Age = 19, IsStudying = true},
                new Student {Id = 3, Name = "Кривецкий Егор", Age = 19, IsStudying = true},
                new Student {Id = 4, Name = "Кобзева Виктория", Age = 18, IsStudying = true},
                new Student {Id = 5, Name = "Казаков Егор", Age = 21, IsStudying = false},
                new Student {Id = 6, Name = "Жизневская Екатерина", Age = 19, IsStudying = true}
        };

        public static List<Student> GetAll()
        {
            return students;
        }

        public static List<Student> Add(Student student)
        {
            students.Add(student);
            return students;
        }

        public static List<Student> Edit(Student student)
        {
            students[student.Id-1] = student;
            return students;
        }

        internal static void Delete(int id)
        {
            var student = students.FirstOrDefault(student => student.Id == id);
            if(student != null)
            {
                students.Remove(student);
            }
        }
    }
}
