using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem.Services
{
    public class ReportService
    {
        private readonly AppDbContext _context;

        public ReportService(AppDbContext context)
        {
            _context = context;
        }

        public void PrintStudentCountPerCourse()
        {
            var result = _context.Courses
                .Include(c => c.Students)
                .Select(c => new { c.Name, StudentCount = c.Students.Count })
                .ToList();

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name}: {item.StudentCount} student(s)");
            }
        }

        public List<Course> GetCoursesWithoutStudents()
        {
            return _context.Courses
                .Include(c => c.Students)
                .Where(c => !c.Students.Any())
                .ToList();
        }

        public List<Student> GetTopStudents(decimal minPercentage)
        {
            return _context.Students
                .Where(s => s.Percentage >= minPercentage)
                .OrderByDescending(s => s.Percentage)
                .ToList();
        }

        public decimal GetAveragePercentage()
        {
            return _context.Students.Average(s => s.Percentage);
        }

        public void PrintInstructorsByCourseCount()
        {
            var result = _context.Instructors
                .Include(i => i.Courses)
                .Select(i => new { i.Name, CourseCount = i.Courses.Count })
                .OrderByDescending(i => i.CourseCount)
                .ToList();

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name}: {item.CourseCount} course(s)");
            }
        }

        public List<Course> GetCoursesLongerThan(int hours)
        {
            return _context.Courses
                .Where(c => c.DurationInHours > hours)
                .OrderBy(c => c.DurationInHours)
                .ToList();
        }
    }
}