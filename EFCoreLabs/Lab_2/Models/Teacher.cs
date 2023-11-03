using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2.Models
{
    public class Teacher
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<Course> Courses { get; set; } = new();
    }
}
