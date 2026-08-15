using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=StudentManagementDB;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //student entity
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.FullName).HasColumnName("Name");

                entity.Property(s => s.Percentage).HasColumnType("decimal(4,2)");
                entity.ToTable(s => s.HasCheckConstraint("CK_Student_Email", "[Email] like '%_@__%__%'"));
                entity.ToTable(s => s.HasCheckConstraint("CK_Student_Age", "[Age]>=16"));
            }
            );
            //course entity
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Description).HasColumnType("varchar(150)");

            }

            );
            //data seeding
            modelBuilder.Entity<Course>().HasData(
        new Course { Id = 1, Name = "C# Fundamentals", Description = "Learn the basics of C# programming language.", DurationInHours = 20 },
        new Course { Id = 2, Name = "ASP.NET Core", Description = "Build web applications using ASP.NET Core.", DurationInHours = 30 },
        new Course { Id = 3, Name = "Entity Framework Core", Description = "Master database access using EF Core.", DurationInHours = 15 },
        new Course { Id = 4, Name = "SQL Server Basics", Description = "Introduction to relational databases and SQL.", DurationInHours = 18 },
        new Course { Id = 5, Name = "React JS", Description = "Build modern front-end applications using React.", DurationInHours = 25 }
    );
            modelBuilder.Entity<Student>().HasData(
        new Student { Id = 1, FullName = "Aya Tamer", Email = "aya.sonbaty@example.com", Age = 21, Percentage = 92.50m },
        new Student { Id = 2, FullName = "Omar Khaled", Email = "omar.khaled@example.com", Age = 22, Percentage = 85.75m },
        new Student { Id = 3, FullName = "Sara Ahmed", Email = "sara.ahmed@example.com", Age = 20, Percentage = 78.30m },
        new Student { Id = 4, FullName = "Mohamed Nabil", Email = "mohamed.nabil@example.com", Age = 23, Percentage = 88.00m },
        new Student { Id = 5, FullName = "Nour Hassan", Email = "nour.hassan@example.com", Age = 19, Percentage = 95.10m },
        new Student { Id = 6, FullName = "Youssef Adel", Email = "youssef.adel@example.com", Age = 24, Percentage = 70.45m },
        new Student { Id = 7, FullName = "Mariam Fathy", Email = "mariam.fathy@example.com", Age = 21, Percentage = 91.20m },
        new Student { Id = 8, FullName = "Karim Tarek", Email = "karim.tarek@example.com", Age = 18, Percentage = 82.60m },
        new Student { Id = 9, FullName = "Salma Ibrahim", Email = "salma.ibrahim@example.com", Age = 20, Percentage = 89.90m },
        new Student { Id = 10, FullName = "Ahmed Ragab", Email = "ahmed.ragab@example.com", Age = 25, Percentage = 76.85m }
    );







        }
    }
}
