
using DAL.Repository;
using DAL.Entities;

namespace DAL.UnitOfWork;

/// <summary> Інтерфейс одиниці роботи над сутностями бази даних.
/// Містить у собі репозиторії сутностей. </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary> Створення транзакції змін у базі даних. </summary>
    void CreateTransaction();

    /// <summary> Застосування транзакції до бази даних. </summary>
    void Commit();

    /// <summary> Відміна транзакції у базі даних. </summary>
    void Rollback();

    /// <summary> Збеження змін у базу даних. </summary>
    void Save();

    /// <summary> Асинхронне збеження змін у базу даних. </summary>
    Task SaveAsync();
    
    /// <summary> Отримання репозиторію сутностей. </summary>
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;
}
