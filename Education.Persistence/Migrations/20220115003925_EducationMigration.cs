using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Persistence.Migrations
{
    public partial class EducationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PublishOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CreatedOn", "Description", "Price", "PublishOn", "Title" },
                values: new object[] { new Guid("356c4854-40e4-4c84-aa11-e22616b00d81"), new DateTime(2022, 1, 14, 19, 39, 25, 586, DateTimeKind.Local).AddTicks(5188), "Curso de C#", 100m, new DateTime(2024, 1, 14, 19, 39, 25, 586, DateTimeKind.Local).AddTicks(5201), "Curso de C# Avanzado" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CreatedOn", "Description", "Price", "PublishOn", "Title" },
                values: new object[] { new Guid("bcae0f48-8fb2-47d0-a8ee-cc24974b4c17"), new DateTime(2022, 1, 14, 19, 39, 25, 586, DateTimeKind.Local).AddTicks(5243), "Curso de React Native", 40m, new DateTime(2024, 1, 14, 19, 39, 25, 586, DateTimeKind.Local).AddTicks(5244), "Curso de React Native Avanzado" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CreatedOn", "Description", "Price", "PublishOn", "Title" },
                values: new object[] { new Guid("c7312d8c-5708-41c3-bd27-c662c1c74f52"), new DateTime(2022, 1, 14, 19, 39, 25, 586, DateTimeKind.Local).AddTicks(5262), "Master en Unit Test", 1000m, new DateTime(2024, 1, 14, 19, 39, 25, 586, DateTimeKind.Local).AddTicks(5263), "Curso de Unit Test Avanzado" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
