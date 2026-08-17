using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementSystem.Services
{
    public class CourseService
    {
        private readonly AppDbContext _context;

        public CourseService(AppDbContext context)
        {
            _context = context;
        }

        // Create
        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        // Read   
        public List<Course> GetAllCourses()
        {
            return _context.Courses.ToList();
        }

        // Read 
        public Course? GetCourseDetails(int id)
        {
            return _context.Courses
                .Include(c => c.Instructor)
                .Include(c => c.Students)
                .FirstOrDefault(c => c.Id == id);
        }

        // Update
        public void UpdateCourse(int id, string name, string description, int durationInHours, int instructorId)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                Console.WriteLine($"Course with Id {id} not found.");
                return;
            }

            course.Name = name;
            course.Description = description;
            course.DurationInHours = durationInHours;
            course.InstructorId = instructorId;

            _context.SaveChanges();
        }

        // Delete
        public void DeleteCourse(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                Console.WriteLine($"Course with Id {id} not found.");
                return;
            }

            _context.Courses.Remove(course);
            _context.SaveChanges();
        }
        // Enroll a student in a course
        public void EnrollStudent(int courseId, int studentId)
        {
            var course = _context.Courses
                .Include(c => c.Students)
                .FirstOrDefault(c => c.Id == courseId);

            var student = _context.Students.FirstOrDefault(s => s.Id == studentId);

            if (course == null)
            {
                Console.WriteLine($"Course with Id {courseId} not found.");
                return;
            }

            if (student == null)
            {
                Console.WriteLine($"Student with Id {studentId} not found.");
                return;
            }

            if (course.Students.Any(s => s.Id == studentId))
            {
                Console.WriteLine($"{student.FullName} is already enrolled in {course.Name}.");
                return;
            }

            course.Students.Add(student);
            _context.SaveChanges();

            Console.WriteLine($"{student.FullName} enrolled in {course.Name} successfully.");
        }
    }
}
