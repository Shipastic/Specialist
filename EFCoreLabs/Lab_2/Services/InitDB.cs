using Lab_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2.Services
{
    public class InitDB
    {
        private readonly ApplicationContext appcontext;

        public InitDB(ApplicationContext context)
        {
            appcontext = context;
        }

        public void Init()
        {
            appcontext.Database.EnsureDeleted();
            appcontext.Database.EnsureCreated();

            var courses = appcontext.Courses.ToList();
            appcontext.Teachers.Find(1).Courses.AddRange(courses);
            appcontext.Teachers.Find(2).Courses.AddRange(courses.GetRange(0, 2));

            for (int i = 1; i <= 4; i++)
                appcontext.Students.Find(i).Courses.AddRange(courses.GetRange(0, i));

            appcontext.SaveChanges();
            Console.WriteLine("Created DB Completed!");
        }
    }
}
