using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "varchar(150)", nullable: false),
                    DurationInHours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.CheckConstraint("CK_Student_Age", "[Age]>=16");
                    table.CheckConstraint("CK_Student_Email", "[Email] like '%_@__%__%'");
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "DurationInHours", "Name" },
                values: new object[,]
                {
                    { 1, "Learn the basics of C# programming language.", 20, "C# Fundamentals" },
                    { 2, "Build web applications using ASP.NET Core.", 30, "ASP.NET Core" },
                    { 3, "Master database access using EF Core.", 15, "Entity Framework Core" },
                    { 4, "Introduction to relational databases and SQL.", 18, "SQL Server Basics" },
                    { 5, "Build modern front-end applications using React.", 25, "React JS" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "Email", "Name", "Percentage" },
                values: new object[,]
                {
                    { 1, 21, "aya.sonbaty@example.com", "Aya Tamer", 92.50m },
                    { 2, 22, "omar.khaled@example.com", "Omar Khaled", 85.75m },
                    { 3, 20, "sara.ahmed@example.com", "Sara Ahmed", 78.30m },
                    { 4, 23, "mohamed.nabil@example.com", "Mohamed Nabil", 88.00m },
                    { 5, 19, "nour.hassan@example.com", "Nour Hassan", 95.10m },
                    { 6, 24, "youssef.adel@example.com", "Youssef Adel", 70.45m },
                    { 7, 21, "mariam.fathy@example.com", "Mariam Fathy", 91.20m },
                    { 8, 18, "karim.tarek@example.com", "Karim Tarek", 82.60m },
                    { 9, 20, "salma.ibrahim@example.com", "Salma Ibrahim", 89.90m },
                    { 10, 25, "ahmed.ragab@example.com", "Ahmed Ragab", 76.85m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
