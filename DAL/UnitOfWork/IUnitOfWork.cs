
using DAL.Repository;
using DAL.Entities;
namespace DAL.UnitOfWork;

/// <summary> Одиниця роботи над сутностями бази даних.
/// Містить у собі репозиторії сутностей. </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary> Збеження змін у базу даних. </summary>
    void Commit();

    /// <summary> Асинхронне збеження змін у базу даних. </summary>
    Task CommitAsync();

    /// <summary> Відміна змін у базі даних. </summary>
    void Rollback();
    
    /// <summary> Отримання репозиторію сутностей. </summary>
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;
}
