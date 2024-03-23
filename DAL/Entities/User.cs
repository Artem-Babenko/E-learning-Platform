namespace DAL.Entities;

/// <summary> Акаунт користувача системи. </summary>
public class User : IEntity
{
    public int Id { get; set; }

    /// <summary> Ім'я користувача. </summary>
    public string? Name { get; set; }

    /// <summary> Прізвище користувача. </summary>
    public string? Surname { get; set; }

    /// <summary> По батькові. </summary>
    public string? Patronymic { get; set; }

    /// <summary> Електронна адреса користувача. 
    /// Використовується для входу у систему. </summary>
    public string? Email { get; set; }

    /// <summary> Пароль користувача. 
    /// Використовується для входу у систему. </summary>
    public string? Password { get; set; } 

    /// <summary> Дата створення акаунта. 
    /// Встановлюється автоматично у конструкторі. </summary>
    public DateTime CreateOn { get; set; }

    /// <summary> Дата народження користувача. Особисті дані. </summary>
    public DateTime BirthDate { get; set; }

    /// <summary> Об'єкт <see cref="Entities.Role"/> користувача. </summary>
    public Role? Role { get; set; }
    
    /// <summary> Ідентифікатод ролі користувача. </summary>
    public int? RoleId { get; set; }

    public User()
    {
        CreateOn = DateTime.Now;
    }
}
