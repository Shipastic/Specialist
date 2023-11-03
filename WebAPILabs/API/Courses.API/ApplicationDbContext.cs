using Courses.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Courses.API
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>()
                .HasData(
                    new Course { Id = 1, Title = "C# Language",        Duration = 40, Description = "C# Language" },
                    new Course { Id = 2, Title = ".Net Client-Server", Duration = 40, Description = "Creating client server for .NET using C#" },
                    new Course { Id = 3, Title = "Pattern",            Duration = 24, Description = "OOP Pattern" },
                    new Course { Id = 4, Title = "JavaScript",         Duration = 24, Description = "JavaScript for web developers" }
                );

            modelBuilder.Entity<Teacher>()
                .HasData(
                    new Teacher() { Id = 1, Name = "Sergey" },
                    new Teacher() { Id = 2, Name = "Fedor" }
                );
            modelBuilder.Entity<Student>()
                .HasData(
                    new Student() { Id = 1, Name = "Anna",   Age = 23 },
                    new Student() { Id = 2, Name = "Alexey", Age = 32 },
                    new Student() { Id = 3, Name = "Andrey", Age = 17 },
                    new Student() { Id = 4, Name = "Helen",  Age = 32 }
                );
        }
    }
}
