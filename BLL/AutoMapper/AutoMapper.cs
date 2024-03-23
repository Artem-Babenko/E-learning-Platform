using AutoMapper;

namespace BLL;

/// <summary> Клас налаштування та отримання екземпляра автоматичного мапера об'єктів. </summary>
internal static class AutoMapper
{
    private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.ShouldMapProperty = p => p.GetMethod!.IsPublic || p.GetMethod.IsAssembly;
            cfg.AddProfile<EntityProfile>();
        });
        var mapper = config.CreateMapper();
        return mapper;
    });

    /// <summary> Отримання екземпляру налаштованого автоматичного мапера. </summary>
    public static IMapper Mapper => Lazy.Value;
}
