using Serilog;

namespace Infrastructure.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Отримання короткої назви контролера. (без слова Controller)
    /// </summary>
    /// <param name="controllerClassName">Повна назва контролера</param>
    public static string ToControllerName(this string controllerClassName)
    {
        var name = controllerClassName.ToLower().Replace("controller", "");
        return name ?? "invalid name";
    }
}
