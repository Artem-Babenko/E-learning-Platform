using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository;

/// <summary> Репозиторій сутностей. Абстракція на контекст бази даних. </summary>
public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    private readonly DatabaseContext db;
    private readonly DbSet<TEntity> entities;

    /// <summary> Конструктор репозиторію. </summary>
    public Repository(DatabaseContext db) 
    {
        this.db = db;
        entities = db.Set<TEntity>();
    }

    /// <summary> Отримання списку сутностей. </summary>
    public IQueryable<TEntity> GetAll()
    {
        return entities;
    }

    /// <summary> Отримання сутності за ідентифікатором. </summary>
    public TEntity? Get(int id)
    {
        var entity = entities.Find(id);
        if (entity == null)
            return null;
        else
            return entity;
    }

    /// <summary> Асинхронне отримання сутності за ідентифікатором. </summary>
    public async Task<TEntity?> GetAsync(int id)
    {
        var entity = await entities.FindAsync(id);
        if (entity == null)
            return null;
        else
            return entity;
    }

    /// <summary> Видалення сутності за ідентифікатором. </summary>
    public bool Remove(int id)
    {
        var product = entities.Find(id);
        if (product != null)
        {
            entities.Remove(product);
            return true;
        }
        return false;
    }

    /// <summary> Видалення сутності. </summary>
    public bool Remove(TEntity entity)
    {
        entities.Remove(entity);
        return true;
    }

    /// <summary> Асинхронне видалення сутності за ідентифікатором. </summary>
    public async Task<bool> RemoveAsync(int id)
    {
        var product = await entities.FindAsync(id);
        if (product != null)
        {
            entities.Remove(product);
            return true;
        }
        return false;
    }

    /// <summary> Додавання сутності. </summary>
    public void Add(in TEntity entity)
    {
        entities.Add(entity).State = EntityState.Added;
    }

    /// <summary> Оновлення сутності. </summary>
    public void Update(in TEntity entity)
    {
        entities.Add(entity).State = EntityState.Modified;
        //entities.Update(entity);
    }

    /// <summary> Збереження репозиторію. </summary>
    public int Save()
    {
        return db.SaveChanges();
    }

    /// <summary> Асинхронне збереження репозиторію. </summary>
    public Task<int> SaveAsync()
    {
        return db.SaveChangesAsync();
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
