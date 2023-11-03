namespace ClassesForLib
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Course> Courses { get; set; } = new();
        public Student()
        {
                
        }
        public Student(int age = 20, string name = "Denis")
        {
            Age = age;
            Name = name;
        }
    }
}
