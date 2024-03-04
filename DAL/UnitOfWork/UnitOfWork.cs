
using DAL.Repository;

namespace DAL.UnitOfWork;

/// <summary> Одиниця роботи над сутностями бази даних.
/// Містить у собі репозиторії сутностей. </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext db;
    private Dictionary<Type, object> repositories;

    /// <summary> Конструктор одиниці роботи. </summary>
    public UnitOfWork()
    {
        db = new DatabaseContext();
        repositories = new Dictionary<Type, object>();
    }

    /// <summary> Збеження змін у базу даних. </summary>
    public void Commit()
    {
        db.SaveChanges();
    }

    /// <summary> Асинхронне збеження змін у базу даних. </summary>
    public async Task CommitAsync()
    {
        await db.SaveChangesAsync();
    }

    /// <summary> Відміна змін у базі даних. </summary>
    public void Rollback()
    {
        db.Database.RollbackTransaction();
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

    #region Dispose

    private bool _disposed = false;

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

    #endregion
}
