namespace Courses.API.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string? Description { get; set; }
        public List<Teacher> Teachers { get; set; } = new();
        public List<Student> Students { get; set; } = new();
    }
}