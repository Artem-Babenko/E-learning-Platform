using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace DAL;

/// <summary> Контекст бази даних для MS SQL Server. (EF Core 8.0.2) </summary>
public partial class DatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public DbSet<Course> Courses { get; set; } = null!;

    public DbSet<Role> Roles { get; set; } = null!;

    public DatabaseContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dbconnection.json");
        if (!File.Exists(path))
            throw new Exception("Файл підключення до бази даних немає або він у іншому місці!");

        var jsonString = File.ReadAllText(path);
        if(string.IsNullOrWhiteSpace(jsonString))
            throw new Exception("Файл підключення до бази даних має невірний формат!");

        var dbConnection = JsonSerializer.Deserialize<DatadaseConnection>(jsonString);
        if(dbConnection == null)
            throw new Exception("Файл підключення до бази даних має недостатньо даних!");

        var connectionString = $"Server={dbConnection.Server}; " +
            $"Database={dbConnection.Database}; " +
            $"Trusted_Connection={dbConnection.Trusted_Connection}; " +
            $"MultipleActiveResultSets={dbConnection.MultipleActiveResultSets}; " +
            $"Encrypt={dbConnection.Encrypt};";

        optionsBuilder.UseSqlServer(connectionString);
    }

   
}

/// <summary> Модель підключення до бд, для десереалізації Json файлу. </summary>
class DatadaseConnection
{
    public string? Server { get; set; }

    public string? Database { get; set; }

    public string? Trusted_Connection { get; set; }

    public string? MultipleActiveResultSets { get; set; }

    public string? Encrypt { get; set; }
}