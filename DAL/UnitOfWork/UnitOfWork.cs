
using DAL.Repository;
using Microsoft.EntityFrameworkCore.Storage;

namespace DAL.UnitOfWork;

/// <summary> Одиниця роботи над сутностями бази даних.
/// Містить у собі репозиторії сутностей. </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext db;
    private Dictionary<Type, object> repositories;
    private bool _disposed = false;

    /// <summary> Конструктор одиниці роботи. </summary>
    public UnitOfWork()
    {
        db = new DatabaseContext();
        repositories = new Dictionary<Type, object>();
    }

    /// <summary> Збереження змін у базі даних. </summary>
    public void Save()
    {
        db.SaveChanges();
    }

    /// <summary> Асинхронне збереження змін у базі даних. </summary>
    public async Task SaveAsync()
    {
        await db.SaveChangesAsync();
    }

    /// <summary> Створення транзакції змін у базі даних. </summary>
    public IDbContextTransaction BeginTransaction()
    {
        return db.Database.BeginTransaction();
    }

    /// <summary> Отримання репозиторію сутностей. </summary>
    IRepository<TEntity> IUnitOfWork.GetRepository<TEntity>()
    {
        if (repositories.ContainsKey(typeof(TEntity)))
        {
            return (IRepository<TEntity>)repositories[typeof(TEntity)];
        }
        var repository = new Repository<TEntity>(db);
        repositories.Add(typeof(TEntity), repository);
        return repository;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
