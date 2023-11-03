namespace ClassesForLib
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; } = new();

        public Teacher(string name = "Sergey")
        {
            Name = name;
        }
    }
}