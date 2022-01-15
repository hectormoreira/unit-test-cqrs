using Education.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Persistence
{
    public class EducationDbContext : DbContext
    {
        public EducationDbContext()
        {
            
        }

        protected EducationDbContext(DbContextOptions<EducationDbContext> options) : base(options)
        { }

        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=ADMINPC\\SQLEXPRESS;database=EducationCqrs;Trusted_Connection=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .Property(e => e.Price)
                .HasPrecision(14, 2);

            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    CourseId = Guid.NewGuid(),
                    Description = "Curso de C#",
                    Title = "Curso de C# Avanzado",
                    CreatedOn = DateTime.Now,
                    PublishOn = DateTime.Now.AddYears(2),
                    Price = 100
                }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    CourseId = Guid.NewGuid(),
                    Description = "Curso de React Native",
                    Title = "Curso de React Native Avanzado",
                    CreatedOn = DateTime.Now,
                    PublishOn = DateTime.Now.AddYears(2),
                    Price = 40
                }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    CourseId = Guid.NewGuid(),
                    Description = "Master en Unit Test",
                    Title = "Curso de Unit Test Avanzado",
                    CreatedOn = DateTime.Now,
                    PublishOn = DateTime.Now.AddYears(2),
                    Price = 1000
                }
            );
        }
    }
}
