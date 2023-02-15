using ACoreBackend.Data;
using ACoreBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace ACoreBackend.Repositories
{
    internal static class StudentRepository
    {

        internal async static Task<List<Student>> GetStudentAsync()
        {
            using (var db = new AppDbContext())
            {
                return await db.Students.ToListAsync();
            }
        }
        internal async static Task<Student> GetStudentByIdAsync(int studentId)
        {
            using (var db = new AppDbContext())
            {
                return await db.Students.FirstOrDefaultAsync(p => p.StudentId == studentId);
            }
        }
        internal static async Task<bool> CreateStudentAsync(Student studentToCreate)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    await db.Students.AddAsync(studentToCreate);
                    return await db.SaveChangesAsync() <= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        internal static async Task<bool> UpdateStudentAsync(Student studentToUpdate)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    db.Students.Update(studentToUpdate);
                    return await db.SaveChangesAsync() <= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        internal static async Task<bool> DeleteStudentAsync(int studentId)
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    Student studentToDelete = await GetStudentByIdAsync(studentId);
                    db.Remove(studentToDelete);
                    return await db.SaveChangesAsync() <= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
