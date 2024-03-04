
namespace DAL.Entities;

/// <summary> Навчальний курс. Збірка матеріалів для навчання. </summary>
public class Course : IEntity
{
    public int Id { get; set; }

    /// <summary> Назва курсу. </summary>
    public string? Name { get; set; }

    /// <summary> Короткий опис про що йтиметься у курсі. </summary>
    public string? Description { get; set; }

    /// <summary> Користувчачі, які приєднані до цього курсу. </summary>
    public List<User> Users { get; set; }

    public Course()
    {
        Users = new List<User>();
    }
}
