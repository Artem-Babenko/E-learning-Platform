
using AutoMapper;

namespace BLL;

/// <summary> Клас налаштування та отримання екземпляра автоматичного мапера об'єктів. </summary>
internal static class AutoMapper
{
    private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
    {
        var config = new MapperConfiguration(cfg =>
        {
            // Налаштування відображення властивостей об'єктів.
            cfg.ShouldMapProperty = p => p.GetMethod!.IsPublic || p.GetMethod.IsAssembly;
            // Додавання профілю мапера.
            cfg.AddProfile<EntityProfile>();
        });
        // Створення екземпляра мапера за конфігурацією.
        var mapper = config.CreateMapper();
        return mapper;
    });

    /// <summary> Отримання екземпляру налаштованого автоматичного мапера. </summary>
    public static IMapper Mapper => Lazy.Value;
}
