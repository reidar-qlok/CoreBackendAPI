using ACoreBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace ACoreBackend.Data
{
    internal sealed class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
      

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder
            .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TimeSystemApiDB;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=true");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Student[] studentToSeed = new Student[6];
            for (int i = 1; i <= 6; i++)
            {
                studentToSeed[i - 1] = new Student
                {
                    StudentId = i,
                    FirstMidName= $"Albert{i}",
                    LastName = $"Nosteen{i}"
                };
            }
            modelBuilder.Entity<Student>().HasData(studentToSeed);
        }
    }
}
