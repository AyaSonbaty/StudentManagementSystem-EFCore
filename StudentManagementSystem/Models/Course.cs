using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int DurationInHours { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();


    }
}
