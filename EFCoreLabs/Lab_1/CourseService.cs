using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    public class CourseService
    {
        private readonly ApplicationContext appcontext;
        private readonly Course _course;
        public CourseService(ApplicationContext context, Course course)
        {
            appcontext = context;
            _course = course;
        }

        public void CreateCourses()
        {

            appcontext.Database.EnsureDeleted();
            appcontext.Database.EnsureCreated();

            Course[] courses = new Course[]
            {
                    new Course() {
                                    Title = "Clien - Server developing on .NET with using C#",
                                    Duration = 40,
                                    Description = "Клиент-Серверная разработка на .NET с исполбзованием языка C#"
                                 },
                    new Course() {
                                    Title = ".NET разработчик серверных приложений ня языке С№",
                                    Duration = 200,
                                    Description = "дипломная программа .NET-разработчик серверных приложений на языке C#"
                                 }
            };

            appcontext.Courses.AddRange(courses);
            appcontext.SaveChanges();
            Console.WriteLine("Modification Saved!");
        }

        public void ReadCourses()
        {

            var courses = appcontext.Courses.ToList();
            Console.WriteLine("Courses list:");
            foreach (Course c in courses)
            {
                Console.WriteLine($"ID: {c.Id}; Title: {c.Title}; Description: {c.Description}; Duration: {c.Duration}");
            }
        }

        public void UpdateCourses(int CourseId)
        {
            var course = appcontext.Courses.Where(c => c.Id == CourseId).FirstOrDefault();
            course.Duration = 1000;
            appcontext.SaveChanges();
            Console.WriteLine($"Updated course with ID = {CourseId}! Current duration: {course.Duration}");
        }
    }
}
