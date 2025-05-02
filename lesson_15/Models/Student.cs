namespace lesson_15.Models
{
    public class Student
    {
        private string Name { get; set; }

        private string Group { get; set; }

        private string Speciality { get; set; }



        public Student(string name, string group, string speciality)
        {
            Name = name;
            Group = group;
            Speciality = speciality;
        }
    }
}
