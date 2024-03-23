using DAL.Repository;
using DAL.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace DAL.UnitOfWork;

/// <summary> Інтерфейс одиниці роботи над сутностями бази даних.
/// Містить у собі репозиторії сутностей. </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary> Отриманння транзакції змін у базі даних. </summary>
    IDbContextTransaction BeginTransaction();

    /// <summary> Збеження змін у базу даних. </summary>
    void Save();

    /// <summary> Асинхронне збеження змін у базу даних. </summary>
    Task SaveAsync();
    
    /// <summary> Отримання репозиторію сутностей. </summary>
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;
}
