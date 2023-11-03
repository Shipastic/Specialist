namespace Courses.API.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; } = new();
    }
}