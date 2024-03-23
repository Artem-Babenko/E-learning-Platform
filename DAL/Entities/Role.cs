namespace DAL.Entities;
 
/// <summary> Роль користувача у цій системі, для авторизації. </summary>
public class Role : IEntity
{
    public int Id { get; set; }

    /// <summary> Назва ролі користувача. </summary>
    public string? Name { get; set; }

    /// <summary> Опис ролі користувача. </summary>
    public string? Description { get; set; }
    
    /// <summary> Код ролі, завдяки ньому буде авторизація.
    /// Наприклад "admin" або "guest". </summary>
    public string? Code { get; set; }

    /// <summary> Список користувачів, які маюсть цю роль. </summary>
    public List<User> Users { get; set; }

    public Role()
    {
        Users = new List<User>();
    }
}
