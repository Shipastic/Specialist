using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System;

namespace Lab_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configuration;

            ConfigurationCSettings settings = new ConfigurationCSettings();
            configuration = settings.GetConfig();

            ApplicationContext applicationContext = new ApplicationContext(configuration);

            Course course = new Course();

            CourseService service = new CourseService(applicationContext, course);
            service.CreateCourses();
            Console.WriteLine("//=================================");
            service.ReadCourses();
            Console.WriteLine("//=================================");
            service.UpdateCourses(1);
            Console.WriteLine("//=================================");
        }
    }

}