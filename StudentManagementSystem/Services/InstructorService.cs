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
    public class InstructorService
    {
        private readonly AppDbContext _context;

        public InstructorService(AppDbContext context)
        {
            _context = context;
        }

        // Create
        public void AddInstructor(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            _context.SaveChanges();
        }

        // Read 
        public List<Instructor> GetAllInstructors()
        {
            return _context.Instructors.ToList();
        }

        // Read 
        public Instructor? GetInstructorWithCourses(int id)
        {
            return _context.Instructors
                .Include(i => i.Courses)
                .FirstOrDefault(i => i.Id == id);
        }

        // Update
        public void UpdateInstructor(int id, string name, string email, string specialization)
        {
            var instructor = _context.Instructors.FirstOrDefault(i => i.Id == id);

            if (instructor == null)
            {
                Console.WriteLine($"Instructor with Id {id} not found.");
                return;
            }

            instructor.Name = name;
            instructor.Email = email;
            instructor.Specialization = specialization;

            _context.SaveChanges();
        }

        // Delete

        public void DeleteInstructor(int id)
        {
            var instructor = _context.Instructors
                .Include(i => i.Courses)
                .FirstOrDefault(i => i.Id == id);

            if (instructor == null)
            {
                Console.WriteLine($"Instructor with Id {id} not found.");
                return;
            }

            if (instructor.Courses.Any())
            {
                Console.WriteLine($"Cannot delete {instructor.Name}: still assigned to {instructor.Courses.Count} course(s).");
                return;
            }

            _context.Instructors.Remove(instructor);
            _context.SaveChanges();
            Console.WriteLine("Instructor deleted successfully.");
        }
    }
}
