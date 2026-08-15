using StudentManagementSystem.Data;

namespace StudentManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new AppDbContext();

            Console.WriteLine("Students:");
            foreach (var student in context.Students)
            {
                Console.WriteLine($"{student.Id} - {student.FullName} - {student.Email} - Age: {student.Age} - {student.Percentage}%");
            }

            Console.WriteLine("\nCourses:");
            foreach (var course in context.Courses)
            {
                Console.WriteLine($"{course.Id} - {course.Name} - {course.DurationInHours} hours");
            }
        }
    }
}
