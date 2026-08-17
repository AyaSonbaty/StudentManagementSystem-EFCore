using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Services
{
    public class StudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        // Create
        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }
        // Read 
        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        // Read 
        public Student? GetStudentById(int id)
        {
            return _context.Students.FirstOrDefault(s => s.Id == id);
        }

        // Update
        public void UpdateStudent(int id, string fullName, string email, int age, decimal percentage)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                Console.WriteLine($"Student with Id {id} not found.");
                return;
            }

            student.FullName = fullName;
            student.Email = email;
            student.Age = age;
            student.Percentage = percentage;

            _context.SaveChanges();
        }

        // Delete
        public void DeleteStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                Console.WriteLine($"Student with Id {id} not found.");
                return;
            }

            _context.Students.Remove(student);
            _context.SaveChanges();
        }
        public Student? GetStudentDetails(int id)
        {
            return _context.Students
                .Include(s => s.Courses)
                .FirstOrDefault(s => s.Id == id);
        }
    }
}
