using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using StudentManagementSystem.Services;
using System;
using System.Linq;

using var context = new AppDbContext();

var studentService = new StudentService(context);
var courseService = new CourseService(context);
var instructorService = new InstructorService(context);
var reportService = new ReportService(context);

// ===== All Students =====
Console.WriteLine("=== All Students ===");
foreach (var student in studentService.GetAllStudents())
    Console.WriteLine($"{student.Id} - {student.FullName} - {student.Email}");

// ===== All Courses =====
Console.WriteLine("\n=== All Courses ===");
foreach (var course in courseService.GetAllCourses())
    Console.WriteLine($"{course.Id} - {course.Name} - {course.DurationInHours}h");

// ===== Enroll Students =====
Console.WriteLine("\n=== Enrolling Students ===");
courseService.EnrollStudent(1, 1);  // Aya Tamer -> C# Fundamentals
courseService.EnrollStudent(1, 2);  // Omar Khaled -> C# Fundamentals
courseService.EnrollStudent(2, 1);  // Aya Tamer -> ASP.NET Core

// ===== Course Details =====
Console.WriteLine("\n=== Course Details (Id = 1) ===");
var courseDetails = courseService.GetCourseDetails(1);
if (courseDetails != null)
{
    Console.WriteLine($"Course: {courseDetails.Name}");
    Console.WriteLine($"Instructor: {courseDetails.Instructor?.Name}");
    Console.WriteLine($"Enrolled Students: {courseDetails.Students.Count}");
    foreach (var s in courseDetails.Students)
        Console.WriteLine($"  - {s.FullName}");
}

// ===== Student Details =====
Console.WriteLine("\n=== Student Details (Id = 1) ===");
var studentDetails = studentService.GetStudentDetails(1);
if (studentDetails != null)
{
    Console.WriteLine($"Student: {studentDetails.FullName}");
    Console.WriteLine($"Enrolled Courses: {studentDetails.Courses.Count}");
    foreach (var c in studentDetails.Courses)
        Console.WriteLine($"  - {c.Name}");
}

// ===== Update Example =====
Console.WriteLine("\n=== Update Student (Id = 3) ===");
studentService.UpdateStudent(3, "Sara Ahmed Updated", "sara.updated@example.com", 21, 85.00m);
var updatedStudent = studentService.GetStudentById(3);
Console.WriteLine($"After update: {updatedStudent?.FullName} - {updatedStudent?.Percentage}%");

// ===== Delete Example =====
Console.WriteLine("\n=== Delete Student (Id = 10) ===");
studentService.DeleteStudent(10);
Console.WriteLine("Attempting to fetch deleted student:");
var deletedStudent = studentService.GetStudentById(10);
Console.WriteLine(deletedStudent == null ? "Confirmed: Student no longer exists." : "Something went wrong.");

// ===== Restrict Delete Example (Instructor with Courses) =====
Console.WriteLine("\n=== Attempt to Delete Instructor with Courses (Id = 1) ===");
instructorService.DeleteInstructor(1);

// ===== Reports =====
Console.WriteLine("\n=== Student Count per Course ===");
reportService.PrintStudentCountPerCourse();

Console.WriteLine("\n=== Courses Without Students ===");
foreach (var c in reportService.GetCoursesWithoutStudents())
    Console.WriteLine($"{c.Name}");

Console.WriteLine("\n=== Top Students (Percentage >= 90) ===");
foreach (var s in reportService.GetTopStudents(90))
    Console.WriteLine($"{s.FullName} - {s.Percentage}%");

Console.WriteLine($"\n=== Average Percentage ===\n{reportService.GetAveragePercentage():0.00}%");

Console.WriteLine("\n=== Instructors by Course Count ===");
reportService.PrintInstructorsByCourseCount();

Console.WriteLine("\n=== Courses Longer Than 18 Hours ===");
foreach (var c in reportService.GetCoursesLongerThan(18))
    Console.WriteLine($"{c.Name} - {c.DurationInHours}h");

Console.WriteLine("\nDone.");


