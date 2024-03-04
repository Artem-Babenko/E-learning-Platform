using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public partial class DatabaseContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Список ролів користувача.
        List<Role> roles = new List<Role>()
        {
            new Role() { Id = 1, Name = "Адміністратор", Code = "admin" },
            new Role() { Id = 2, Name = "Викладач", Code = "teacher" },
            new Role() { Id = 3, Name = "Студент", Code = "student" },
            new Role() { Id = 4, Name = "Гість", Code = "guest" }
        };

        // Назви таблиць та їх початкові дані.
        modelBuilder.Entity<User>().ToTable("User");
        modelBuilder.Entity<Course>().ToTable("Course");
        modelBuilder.Entity<Role>().ToTable("Role").HasData(roles);
    }
}
