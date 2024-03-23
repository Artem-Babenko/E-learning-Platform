using DAL.Entities;

namespace DAL.Repository;

/// <summary> Інтерфейс репозиторію сутностей. Абстракція на контекст бази даних. </summary>
public interface IRepository<TEntity> : IDisposable where TEntity : class, IEntity
{
    /// <summary> Отримання списку сутностей. </summary>
    IQueryable<TEntity> GetAll();

    /// <summary> Отримання сутності за ідентифікатором. </summary>
    TEntity? Get(int id);

    /// <summary> Асинхронне отримання сутності за ідентифікатором. </summary>
    Task<TEntity?> GetAsync(int id);

    /// <summary> Видалення сутності за ідентифікатором. </summary>
    bool Remove(int id);

    /// <summary> Видалення сутності. </summary>
    bool Remove(TEntity entity);

    /// <summary> Асинхронне видалення сутності за ідентифікатором. </summary>
    Task<bool> RemoveAsync(int id);

    /// <summary> Додавання сутності. </summary>
    void Add(in TEntity entity);

    /// <summary> Оновлення сутності. </summary>
    void Update(in TEntity entity);

    /// <summary> Збереження репозиторію. </summary>
    int Save();

    /// <summary> Асинхронне збереження репозиторію. </summary>
    Task<int> SaveAsync();
}