using Lab_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2.Services
{
    public class StudentInfoService
    {
        private readonly ApplicationContext _context;
        public StudentInfoService(ApplicationContext context)
        {
            _context = context;
        }

        public void OutputInfoStudent()
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("Output Info from DB:");
            var r = from t in _context.Teachers
                    orderby t.Name
                    select new { Teacher = t, Courses = t.Courses };

            foreach (var t in r.ToList())
            {
                Console.WriteLine(t.Teacher.Name);
                foreach (var c in t.Courses)
                {
                    Console.WriteLine($"\t{c.Title}");
                    var r2 = from s in _context.Students
                             where s.Courses.Contains(c)
                             orderby s.Name
                             select s;
                    foreach (var s in r2)
                        Console.WriteLine($"\t\t{s.Name}");
                }
            }
        }
    }    
}
